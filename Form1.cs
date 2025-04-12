using DataViewerFront.Services;

namespace DataViewerFront
{
    public partial class Form1 : Form
    {

        private readonly ApiService _apiService;

        public Form1()
        {
            InitializeComponent();
            progressBar1.Hide();
            _apiService = new ApiService();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Select a file";
            fileDialog.InitialDirectory = @"C:\";
            fileDialog.Multiselect = false;
            fileDialog.Filter = "Only video files allowed (*.mp4, *.ts)|*.mp4;*.ts";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = fileDialog.FileName;

                progressBar1.Show();

                var apiService = new ApiService();

                try
                {
                    await apiService.UploadFileAsync(filePath, progress =>
                    {
                        Invoke(new Action(() =>
                        {
                            progressBar1.Value = progress;
                        }));
                    });

                    MessageBox.Show("File uploaded successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
