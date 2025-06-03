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
    public partial class PopUpEditOnboard : Form
    {

        private int? _videoId;
        private int _timestamp;
        private List<string> _drivers;

        private readonly VideoService _videoService;

        public PopUpEditOnboard(int? videoId, int timestamp, List<string> drivers, string currentDriverAbbr, string currentDriverName)
        {
            InitializeComponent();
            _videoService = new VideoService();
            _videoId = videoId;
            _timestamp = timestamp;
            _drivers = drivers;

            comboDrivers.DataSource = _drivers;

            comboDrivers.SelectedItem = "("+currentDriverAbbr+") "+currentDriverName;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

        }
    }
}
