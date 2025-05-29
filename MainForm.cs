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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Ejemplo: obtener el valor de la primera celda (columna 0)
                var selectedItem = selectedRow.DataBoundItem as ResponseVideoDto;

                _selectedVideoId = selectedItem.VideoId;

                button1.Enabled = true;

                if (dataGridView1.Columns[e.ColumnIndex].Name == "Player")
                {
                    var row = dataGridView1.Rows[e.RowIndex];
                    if (row.DataBoundItem is ResponseVideoDto video && video.ShowPlayer)
                    {
                        var videoPlayer = new VideoPlayerForm(_selectedVideoId);
                        videoPlayer.Show();
                    }
                }

            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = comboBox1.Items[0];
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
            byte[] imageData = Properties.Resources.play;
            Image playIcon;

            using (var ms = new MemoryStream(imageData))
            {
                playIcon = Image.FromStream(ms);
            }


            var playerColumn = new DataGridViewTextBoxColumn
            {
                Name = "Player",
                HeaderText = "Player",
                Width = 50,
                ReadOnly = true

            };
            playerColumn.DefaultCellStyle.NullValue = null;
            dataGridView1.Columns.Add(playerColumn);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.DataBoundItem is ResponseVideoDto video && video.ShowPlayer)
                {
                    row.Cells["Player"].Value = video.ShowPlayer ? "PLAY" : null;
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

            MessageBox.Show("Video processing started. It could take some minutes, depending on file size.");
            var selected = comboBox1.SelectedItem.ToString();
            var threshold = int.Parse(selected.TrimEnd('s'));
            await _videoService.ProcessVideo(_selectedVideoId, threshold);
            await LoadVideos();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            await LoadVideos();
        }
    }
}
