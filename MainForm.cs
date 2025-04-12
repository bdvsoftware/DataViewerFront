using DataViewerFront.Services;

namespace DataViewerFront
{
    public partial class MainForm : Form
    {

        

        public MainForm()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PopUpUploadVideoForm popUpUploadVideo = new PopUpUploadVideoForm();
            popUpUploadVideo.Show();
        }
    }
}
