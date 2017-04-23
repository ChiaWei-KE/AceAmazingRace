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
        private readonly List<List<RealTimeData>> _sampleLiveData;
        private static int _counter;

        public Form1()
        {
            _sampleLiveData = new List<List<RealTimeData>>()
            {
	            new List<RealTimeData>() { new RealTimeData(1, 1.001, 200.02), new RealTimeData(2, 2.002, 300.03), new RealTimeData(3, 3.003, 400.04)},
	            new List<RealTimeData>() { new RealTimeData(1, 4.004, 500.05), new RealTimeData(2, 5.005, 600.06), new RealTimeData(3, 6.006, 700.07)},
	            new List<RealTimeData>() { new RealTimeData(1, 7.007, 800.08), new RealTimeData(2, 8.008, 900.09), new RealTimeData(3, 9.009, 1000.1)},
	            new List<RealTimeData>() { new RealTimeData(1, 7.007, 800.08), new RealTimeData(2, 8.008, 900.09), new RealTimeData(3, 9.009, 1000.1)},
	            new List<RealTimeData>() { new RealTimeData(1, 7.007, 800.08), new RealTimeData(2, 8.008, 900.09), new RealTimeData(3, 9.009, 1000.1)}
            };

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
 
                txtOutput.Text += Environment.NewLine + $"The response are {data.Result}";
                _counter++;
             }

        }

        private void txtOutput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
