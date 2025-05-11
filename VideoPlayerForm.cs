using System.Collections.Generic;
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
        private string _videoPath;
        private List<string> _drivers;
        private MediaPlayer _mediaPlayer;
        private LibVLC _libVLC;
        private bool _isDragging = false;

        public VideoPlayerForm(int? videoId)
        {
            InitializeComponent();
            _videoService = new VideoService();
            _videoPath = "";
            _drivers = new List<string>();
            _videoId = videoId;
            _libVLC = new LibVLC();
            _mediaPlayer = new MediaPlayer(_libVLC);
        }

        private async void VideoPlayerForm_Load(object sender, EventArgs e)
        {
            _videoData = await _videoService.GetVideoData(_videoId);
            _drivers.Add("All");
            _drivers.AddRange(_videoData.Keys.ToList());
            comboBox1.DataSource = _drivers;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            LoadTablesData();
            _videoPath = await _videoService.GetVideoPath(_videoId);
            timer1.Start();

            try
            {
                Core.Initialize();
                videoView1.MediaPlayer = _mediaPlayer;

                Controls.Add(videoView1);

                var media = new Media(_libVLC, new Uri(_videoPath));
                _mediaPlayer.Play(media);

                labelCurrentTime.Text = TimeSpan.FromMilliseconds(0).ToString(@"hh\:mm\:ss");
                labelTotalTime.Text = TimeSpan.FromMilliseconds(_mediaPlayer.Position).ToString(@"hh\:mm\:ss");
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading player");
            }

            Console.WriteLine("data");
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTablesData();
        }

        private void LoadTablesData()
        {
            var driver = comboBox1.SelectedItem.ToString();
            if (driver.Equals("All"))
            {
                LoadAllDriversData();
            }
            else
            {
                LoadDataDriver(driver);
            }

        }

        private void LoadAllDriversData()
        {
            var onboardData = new List<DriverOnboardRangeDto>();
            var batteryData = new List<DriverBatteryRangeDto>();
            foreach (var driver in _videoData.Keys)
            {
                if (_videoData[driver] != null && _videoData[driver].DriverOnboardRangeDto != null)
                {
                    onboardData.AddRange(_videoData[driver].DriverOnboardRangeDto);
                }
                if (_videoData[driver] != null && _videoData[driver].DriverBatteryRangeDto != null)
                {
                    batteryData.AddRange(_videoData[driver].DriverBatteryRangeDto);
                }
            }
            InitializeOnboardTable(onboardData);
            if (onboardData.Any())
            {
                dataGridView1.Visible = true;
            }
            InitializeBatteryTable(batteryData);
            if (batteryData.Any())
            {
                dataGridView2.Visible = true;
            }
        }

        private void InitializeOnboardTable(List<DriverOnboardRangeDto> onboardData)
        {
            dataGridView1.DataSource = onboardData;
            dataGridView1.Columns["OnboardFrameId"].Visible = false;
            dataGridView1.Columns["TimeRange"].HeaderText = "Time";
            dataGridView1.Columns["TeamName"].Visible = false;
            dataGridView1.Columns["DriverName"].Visible = false;
            dataGridView1.Columns["DriverAbbreviation"].HeaderText = "Driver";
            int totalHeight = dataGridView1.ColumnHeadersVisible ? dataGridView1.ColumnHeadersHeight : 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                totalHeight += row.Height;
            }
            dataGridView1.Height = totalHeight;
        }

        private void InitializeBatteryTable(List<DriverBatteryRangeDto> batteryData)
        {
            dataGridView2.DataSource = batteryData;

            dataGridView2.Columns["FrameId"].Visible = false;
            dataGridView2.Columns["BatteryFrameId"].Visible = false;
            dataGridView2.Columns["DriverName"].Visible = false;
            dataGridView2.Columns["DriverAbbreviation"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView2.Columns["Lap"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView2.Columns["Status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView2.Columns["TimeRange"].HeaderText = "Time";
            dataGridView2.Columns["DriverAbbreviation"].HeaderText = "Driver";
            int totalHeight = dataGridView2.ColumnHeadersVisible ? dataGridView2.ColumnHeadersHeight : 0;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                totalHeight += row.Height;
            }
            dataGridView2.Height = totalHeight;
        }

        private void LoadDataDriver(string driver)
        {
            var driverData = _videoData[driver];

            var onboardData = driverData.DriverOnboardRangeDto;
            var batteryData = driverData.DriverBatteryRangeDto;

            if (onboardData.Any())
            {
                LoadOnboardTable(onboardData);
            }
            else
            {
                dataGridView1.Visible = false;
                onboardsLabel.Visible = false;
            }
            if (batteryData.Any())
            {
                LoadBatteryTable(batteryData);
            }
            else
            {
                dataGridView2.Visible = false;
                batteryLabel.Visible = false;
            }
        }

        private void LoadOnboardTable(IEnumerable<DriverOnboardRangeDto> onboardData)
        {
            InitializeOnboardTable(onboardData.ToList());
            dataGridView1.Visible = true;
            onboardsLabel.Visible = true;
        }

        private void LoadBatteryTable(IEnumerable<DriverBatteryRangeDto> batteryData)
        {
            InitializeBatteryTable(batteryData.ToList());
            dataGridView2.Visible = true;
            batteryLabel.Visible = true;
        }

        public void DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != null && e.ColumnIndex.Equals(6))
            {
                var value = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                var startTime = value.Split(new[] { " - " }, StringSplitOptions.None)[0];
                var timeSpan = TimeSpan.Parse(startTime);
                _mediaPlayer.SeekTo(timeSpan);
            }
        }

        public void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != null && e.ColumnIndex.Equals(4))
            {
                var value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                var startTime = value.Split(new[] { " - " }, StringSplitOptions.None)[0];
                var timeSpan = TimeSpan.Parse(startTime);
                _mediaPlayer.SeekTo(timeSpan);
                long currentTime = _mediaPlayer.Time;
                labelCurrentTime.Text = TimeSpan.FromMilliseconds(currentTime).ToString(@"hh\:mm\:ss");
                float position = _mediaPlayer.Position;
                trackBar1.Value = Math.Min(trackBar1.Maximum, (int)(position * trackBar1.Maximum));
            }
        }

        public void Timer_Tick(object sender, EventArgs e)
        {
            if (_mediaPlayer == null || !_mediaPlayer.IsPlaying || _isDragging)
                return;

            long currentTime = _mediaPlayer.Time;
            long totalTime = _mediaPlayer.Length;
            labelCurrentTime.Text = TimeSpan.FromMilliseconds(currentTime).ToString(@"hh\:mm\:ss");
            labelTotalTime.Text = TimeSpan.FromMilliseconds(totalTime).ToString(@"hh\:mm\:ss");

            if (totalTime > 0)
            {
                float position = _mediaPlayer.Position;
                trackBar1.Value = Math.Min(trackBar1.Maximum, (int)(position * trackBar1.Maximum));
            }
        }

        public void trackBar1_MouseDown(object sender, EventArgs e)
        {
            _isDragging = true;
        }

        public void trackBar1_MouseUp(object sender, EventArgs e)
        {
            _isDragging = false;
            var position = (float)trackBar1.Value / trackBar1.Maximum;
            _mediaPlayer.Position = position;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            long currentTime = _mediaPlayer.Time;
            currentTime += 5000;

            if (currentTime > _mediaPlayer.Length)
            {
                currentTime = _mediaPlayer.Length;
            }

            _mediaPlayer.Time = currentTime;
            labelCurrentTime.Text = TimeSpan.FromMilliseconds(currentTime).ToString(@"hh\:mm\:ss");
            float position = _mediaPlayer.Position;
            trackBar1.Value = Math.Min(trackBar1.Maximum, (int)(position * trackBar1.Maximum));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            long currentTime = _mediaPlayer.Time;
            currentTime -= 5000;

            if (currentTime < 0)
            {
                currentTime = 0;
            }

            _mediaPlayer.Time = currentTime;
            labelCurrentTime.Text = TimeSpan.FromMilliseconds(currentTime).ToString(@"hh\:mm\:ss");
            float position = _mediaPlayer.Position;
            trackBar1.Value = Math.Min(trackBar1.Maximum, (int)(position * trackBar1.Maximum));
        }
    }
}
