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
        private List<string> _drivers;
        private int? _currentLap;
        private string _initTime;
        private string _endTime;

        private readonly FrameService _frameService;

        public PopUpEditOnboard(int? videoId, List<string> drivers, string currentDriverAbbr, string currentDriverName, int? currentLap, string initTime, string endTime)
        {
            InitializeComponent();
            _frameService = new FrameService();
            _videoId = videoId;
            _drivers = drivers;
            _currentLap = currentLap;
            _initTime = initTime;
            _endTime = endTime;

            comboDrivers.DataSource = _drivers;

            comboDrivers.SelectedItem = "(" + currentDriverAbbr + ") " + currentDriverName;

            textBoxFrom.Text = initTime;
            textBoxTo.Text = endTime;

            comboLaps.DataSource = Enumerable.Range(0, 100).ToList();
            
            if(currentLap != null)
            {
                comboLaps.SelectedItem = currentLap.Value;
            }
        }

        private async void saveButton_Click(object sender, EventArgs e)
        {
            var driverAbbr = GetDriverAbbreviation(comboDrivers.SelectedItem.ToString());
            await _frameService.UpdateFrameData(_videoId, ToSeconds(_initTime), ToSeconds(_endTime), _currentLap, driverAbbr);
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

        private int ToSeconds(string time)
        {
            if (TimeSpan.TryParse(time, out TimeSpan ts))
            {
                return (int)ts.TotalSeconds;
            }
            throw new FormatException($"Invalid format: '{time}'");
        }
    }
}
