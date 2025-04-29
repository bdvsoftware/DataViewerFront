using System.Resources;
using System.Security.Cryptography;
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
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();

            dataGridView1.DataSource = _videos;

            dataGridView1.Columns["VideoId"].Visible = false;
            dataGridView1.Columns["SessionId"].Visible = false;
            dataGridView1.Columns["ShowPlayer"].Visible = false;
            Image playIcon = Image.FromFile("C:/racing/DataViewerFront/Resources/Img/play.png");


            var iconColumn = new DataGridViewImageColumn
            {
                Name = "PlayIcon",
                HeaderText = "Player",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 50

            };
            iconColumn.DefaultCellStyle.NullValue = null;
            dataGridView1.Columns.Add(iconColumn);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.DataBoundItem is ResponseVideoDto video && video.ShowPlayer)
                {
                    row.Cells["PlayIcon"].Value = video.ShowPlayer ? playIcon : null;
                }
            }

            // Ajustar tamaño del DataGridView
            int totalHeight = dataGridView1.ColumnHeadersHeight;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                totalHeight += row.Height;
            }

            int totalWidth = dataGridView1.RowHeadersWidth;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                totalWidth += column.Width;
            }

            dataGridView1.Height = totalHeight;
            dataGridView1.Width = totalWidth;
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

        private async void button3_Click(object sender, EventArgs e)
        {
            await LoadVideos();
        }
    }
}
