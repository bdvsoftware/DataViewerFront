using System.Threading.Tasks;
using DataViewerFront.Dtos;
using DataViewerFront.Services;

namespace DataViewerFront
{
    public partial class MainForm : Form
    {

        private IEnumerable<ResponseVideoDto> _videos;

        private readonly VideoService _videoService;

        private int? _selectedVideoId;

        public MainForm()
        {
            InitializeComponent();
            _videoService = new VideoService();
            _selectedVideoId = null;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("aaaaaa");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Ejemplo: obtener el valor de la primera celda (columna 0)
                var selectedItem = selectedRow.DataBoundItem as ResponseVideoDto;

                _selectedVideoId = selectedItem.VideoId;

                button1.Enabled = true;

            }
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

        private async void button1_Click(object sender, EventArgs e)
        {
            await _videoService.ProcessVideo(_selectedVideoId);
            await LoadVideos();
            MessageBox.Show("Video processing started.");
        }

        private async Task button3_Click(object sender, EventArgs e)
        {
            await LoadVideos();
        }
    }
}
