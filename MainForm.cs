using DataViewerFront.Dtos;
using DataViewerFront.Services;

namespace DataViewerFront
{
    public partial class MainForm : Form
    {

        private IEnumerable<ResponseVideoDto> _videos;

        private readonly VideoService _videoService;

        private int _selectedVideoId;

        public MainForm()
        {
            InitializeComponent();
            _videoService = new VideoService();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("aaaaaa");
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadVideos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PopUpUploadVideoForm popUpUploadVideo = new PopUpUploadVideoForm();
            popUpUploadVideo.FormClosed += PopUpUploadVideo_FormClosed;
            popUpUploadVideo.Show();
        }

        private async Task LoadVideos()
        {
            _videos = await _videoService.GetVideos();
            dataGridView1.DataSource = _videos;
            dataGridView1.Columns["VideoId"].Visible = false;
            dataGridView1.Columns["SessionId"].Visible = false; int totalHeight = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                totalHeight += row.Height;
            }

            int totalWidth = 0;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                totalWidth += column.Width;
            }

            dataGridView1.Height = totalHeight + dataGridView1.ColumnHeadersHeight;  
            dataGridView1.Width = totalWidth + dataGridView1.RowHeadersWidth;
        }

        private async void PopUpUploadVideo_FormClosed(object sender, FormClosedEventArgs e)
        {
            await LoadVideos();
        }
    }
}
