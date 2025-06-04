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

        private readonly FrameService _frameService;

        public PopUpEditOnboard(int? videoId, int timestamp, List<string> drivers, string currentDriverAbbr, string currentDriverName)
        {
            InitializeComponent();
            _frameService = new FrameService();
            _videoId = videoId;
            _timestamp = timestamp;
            _drivers = drivers;

            comboDrivers.DataSource = _drivers;

            comboDrivers.SelectedItem = "("+currentDriverAbbr+") "+currentDriverName;
        }

        private async void saveButton_Click(object sender, EventArgs e)
        {
            var driverAbbr = GetDriverAbbreviation(comboDrivers.SelectedItem.ToString());
            await _frameService.UpdateFrameData(_videoId, _timestamp, 1, driverAbbr);
        }

        private string GetDriverAbbreviation(string comboDrivers)
        {
            if (string.IsNullOrWhiteSpace(comboDrivers))
                return string.Empty;

            int start = comboDrivers.IndexOf('(');
            int end = comboDrivers.IndexOf(')');

            if (start >= 0 && end > start)
            {
                return comboDrivers.Substring(start + 1, end - start - 1);
            }

            return string.Empty;
        }
    }
}
