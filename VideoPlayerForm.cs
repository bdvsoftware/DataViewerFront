using DataViewerFront.Dtos;
using DataViewerFront.Services;
using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;

namespace DataViewerFront
{
    public partial class VideoPlayerForm : Form
    {

        private readonly VideoService _videoService;
        private readonly int? _videoId;
        private Dictionary<string, DriverVideoDto> _videoData;
        private Dictionary<string, DriverData> _processedVideoData;
        private string _videoPath;
        private MediaPlayer _mediaPlayer;
        private LibVLC _libVLC;
        private Button _playButton;
        private Button _pauseButton;
        private Button _stopButton;
        private TrackBar _progressBar;

        public VideoPlayerForm(int? videoId)
        {
            InitializeComponent();
            _videoService = new VideoService();
            _processedVideoData = new Dictionary<string, DriverData>();
            _videoPath = "";
            _videoId = videoId;
            _libVLC = new LibVLC();
            _mediaPlayer = new MediaPlayer(_libVLC);
        }

        private async void VideoPlayerForm_Load(object sender, EventArgs e)
        {
            _videoData = await _videoService.GetVideoData(_videoId);
            _videoPath = await _videoService.DownloadVideoAsync(_videoId);
            processVideoData();
            populateTreeView();
            try
            {
                Core.Initialize();
                videoView1.MediaPlayer = _mediaPlayer;

                Controls.Add(videoView1);

                var media = new Media(_libVLC, new Uri(_videoPath));
                _mediaPlayer.Play(media);
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading player");
            }

            Console.WriteLine("data");
        }

        private void processVideoData()
        {
            foreach (var driver in _videoData.Keys)
            {
                var onboardData = _videoData[driver].DriverOnboardDto;
                var batteryData = _videoData[driver].DriverBatteryDto;

                var timestampsOnboards = new List<int>();
                var timestampsBattery = new List<int>();

                if (onboardData != null)
                {
                    foreach (var onboardFrame in onboardData)
                    {
                        timestampsOnboards.Add(onboardFrame.Timestamp);
                    }
                }
                if (batteryData != null)
                {
                    foreach (var batteryFrame in batteryData)
                    {
                        timestampsBattery.Add(batteryFrame.Timestamp);
                    }
                }
                var data = new DriverData(timestampsOnboards, timestampsBattery);
                _processedVideoData.TryAdd(driver, data);
            }
        }

        private void populateTreeView()
        {
            treeView1.Nodes.Clear();
            foreach (var driver in _processedVideoData.Keys)
            {
                TreeNode driverNode = new TreeNode(driver);
                TreeNode onboardNode = new TreeNode("Onboards");
                foreach (var timestamp in _processedVideoData[driver].onboardTimestamps)
                {
                    onboardNode.Nodes.Add(ConvertSecondsToTimeFormat(timestamp));
                }
                TreeNode batteryNode = new TreeNode("Battery");
                foreach (var timestamp in _processedVideoData[driver].batteryTimestamps)
                {
                    batteryNode.Nodes.Add(ConvertSecondsToTimeFormat(timestamp));
                }
                driverNode.Nodes.Add(onboardNode);
                driverNode.Nodes.Add(batteryNode);
                treeView1.Nodes.Add(driverNode);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _mediaPlayer.Pause();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _mediaPlayer.Play();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent != null
                && (e.Node.Parent.Text == "Onboards" || e.Node.Parent.Text == "Battery"))
            {
                if (TimeSpan.TryParse(e.Node.Text, out TimeSpan time))
                {
                    _mediaPlayer.SeekTo(time);

                }
                else
                {
                    MessageBox.Show($"Formato de tiempo no válido: {e.Node.Text}\nUsa hh:mm:ss");
                }
            }
        }

        private string ConvertSecondsToTimeFormat(int seconds)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
            return timeSpan.ToString(@"hh\:mm\:ss");
        }
    }
}
