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
        List<List<ReadTimeData>> sampleLiveData = new List<List<ReadTimeData>>();
        private static int counter = 0;

        public Form1()
        {
            var data1 = new List<ReadTimeData>
            {
                new ReadTimeData() {  TeamIndex = 1, Latitude = 1.001,Longitude = 200.02},
                new ReadTimeData() {  TeamIndex = 2, Latitude = 2.002,Longitude = 300.03},
                new ReadTimeData() {  TeamIndex = 3, Latitude = 3.003,Longitude = 400.04}
            };

            var data2 = new List<ReadTimeData>
            {
                new ReadTimeData() {  TeamIndex = 4, Latitude = 4.004,Longitude = 5.005},
                new ReadTimeData() {  TeamIndex = 5, Latitude = 5.005,Longitude = 600.06},
                new ReadTimeData() {  TeamIndex = 6, Latitude = 6.006,Longitude = 700.07}
            };

            var data3 = new List<ReadTimeData>
            {
                new ReadTimeData() {  TeamIndex = 7, Latitude = 7.007,Longitude = 800.08},
                new ReadTimeData() {  TeamIndex = 8, Latitude = 8.008,Longitude = 900.09},
                new ReadTimeData() {  TeamIndex = 9, Latitude = 9.009,Longitude = 1000.10}
            };

            sampleLiveData.Add(data1);
            sampleLiveData.Add(data2);
            sampleLiveData.Add(data3);

            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (counter >= sampleLiveData.Count) return;

            var myContent = JsonConvert.SerializeObject(sampleLiveData[counter]);

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
                counter++;
             }

        }

        private void txtOutput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
