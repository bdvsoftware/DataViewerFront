using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataViewerFront.Services;

namespace DataViewerFront
{
    public partial class PopUpUploadVideoForm : Form
    {

        private readonly ApiService _apiService;

        public PopUpUploadVideoForm()
        {
            InitializeComponent();
            _apiService = new ApiService();
        }

        private async void PopUpUploadVideoForm_Load(object sender, EventArgs e)
        {
            
        }

        private async void UploadButton_Click(object sender, EventArgs e)
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
            Close();
        }
    }
}
