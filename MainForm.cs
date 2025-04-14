using DataViewerFront.Dtos;
using DataViewerFront.Services;

namespace DataViewerFront
{
    public partial class MainForm : Form
    {

        private IEnumerable<ResponseVideoDto> _videos;

        private readonly VideoService _videoService;

        public MainForm()
        {
            InitializeComponent();
            _videoService = new VideoService();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            _videos = await _videoService.GetVideos();
            dataGridView1.DataSource = _videos;
            dataGridView1.Columns["VideoId"].Visible = false;
            dataGridView1.Columns["SessionId"].Visible = false; int totalHeight = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                totalHeight += row.Height;
            }

            // Ajustar el tamaño total (ancho) del DataGridView según las columnas
            int totalWidth = 0;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                totalWidth += column.Width;
            }

            // Establecer el tamaño del DataGridView para que coincida con el contenido
            dataGridView1.Height = totalHeight + dataGridView1.ColumnHeadersHeight;  // Incluir altura de los encabezados
            dataGridView1.Width = totalWidth + dataGridView1.RowHeadersWidth;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PopUpUploadVideoForm popUpUploadVideo = new PopUpUploadVideoForm();
            popUpUploadVideo.Show();
        }
    }
}
