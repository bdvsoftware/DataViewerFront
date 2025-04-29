using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        private VideoView _videoView;

        public VideoPlayerForm(int? videoId)
        {
            InitializeComponent();
            _videoService = new VideoService();
            _processedVideoData = new Dictionary<string, DriverData>();
            _videoPath = "";
            _videoId = videoId;
            _libVLC = new LibVLC();
            _mediaPlayer = new MediaPlayer(_libVLC);
            _videoView = null;
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
                _videoView = new VideoView
                {
                    MediaPlayer = _mediaPlayer,
                    Dock = DockStyle.Left,
                    Width = this.ClientSize.Width / 2
                };
                _videoView.MediaPlayer = _mediaPlayer;

                Controls.Add(_videoView);

                var media = new Media(_libVLC, new Uri(_videoPath));
                _mediaPlayer.Play(media);
            }catch (Exception ex)
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
                foreach(var timestamp in _processedVideoData[driver].onboardTimestamps)
                {
                    onboardNode.Nodes.Add(timestamp.ToString());
                }
                TreeNode batteryNode = new TreeNode("Battery");
                foreach (var timestamp in _processedVideoData[driver].batteryTimestamps)
                {
                    batteryNode.Nodes.Add(timestamp.ToString());
                }
                driverNode.Nodes.Add(onboardNode);
                driverNode.Nodes.Add(batteryNode);  
                treeView1.Nodes.Add(driverNode);
            }
        }
    }
}
