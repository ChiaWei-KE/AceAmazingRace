using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AceAmazingRace.ViewModels;
using Newtonsoft.Json;

namespace Simulator
{
    public partial class Form1 : Form
    {
        private static List<List<RealTimeData>> _sampleLiveData;
        private static int _counter;
        private static int _total;

        public Form1()
        {
            _sampleLiveData = new List<List<RealTimeData>>()
            {
	            new List<RealTimeData>() { new RealTimeData(1, 1.300029, 103.855058), new RealTimeData(2, 1.29833, 103.85566), new RealTimeData(3, 1.2994, 103.85421)},
	            new List<RealTimeData>() { new RealTimeData(1, 1.30051, 103.85633), new RealTimeData(2, 1.29779, 103.85505), new RealTimeData(3, 1.29972, 103.85466)},
	            new List<RealTimeData>() { new RealTimeData(1, 1.30022, 103.85633), new RealTimeData(2, 1.29773, 103.85464), new RealTimeData(3, 1.30037, 103.85505)}
            };

            _total = _sampleLiveData.Count;
            _counter = 0;
            
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (_counter >= _sampleLiveData.Count) return;

            var myContent = JsonConvert.SerializeObject(_sampleLiveData[_counter]);

            var baseUrl = "http://localhost:50842";
            
            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri(baseUrl);
             
                var url = "api/common/simulate";
                
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


                var response = client.PostAsync(url, byteContent).Result;
                var data = response.Content.ReadAsStringAsync();
 
                txtOutput.Text = $@"{DateTime.Now} - {data.Result}" + Environment.NewLine + txtOutput.Text;
                UpdateStat();
                _counter++;
            }

        }

        private void txtOutput_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnResetLocations_Click(object sender, EventArgs e)
        {
            _counter = 0;
            txtOutput.Text = "";
        }

        private void UpdateStat()
        {
            lblSteps.Text = $@"{_counter + 1:00}/{_total:00}";
        }
    }
}
