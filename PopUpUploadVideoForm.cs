﻿using System;
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

        private readonly VideoService _videoService;
        private readonly GrandPrixService _grandPrixService;
        private readonly SessionTypeService _sessionTypeService;

        public PopUpUploadVideoForm()
        {
            InitializeComponent();
            _videoService = new VideoService();
            _grandPrixService = new GrandPrixService();
            _sessionTypeService = new SessionTypeService();
        }

        private async void PopUpUploadVideoForm_Load(object sender, EventArgs e)
        {
            var gpNames = await _grandPrixService.GetAllGrandPrixNamesAsync();
            comboGp.DataSource = gpNames;
            var sessionTypeNames = await _sessionTypeService.GetAllSessionTypeNamesAsync();
            comboSessionType.DataSource = sessionTypeNames;
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

                try
                {
                    await _videoService.UploadFileAsync(filePath, comboGp.SelectedItem.ToString(), comboSessionType.SelectedItem.ToString(), progress =>
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
