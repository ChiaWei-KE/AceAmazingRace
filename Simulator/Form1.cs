using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            var baseUrl = "http://localhost:50842";
            
            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri(baseUrl);
             
                var url = "api/common/simulate";
                var pairs = new List<KeyValuePair<string, string>>() {};
                var content = new FormUrlEncodedContent(pairs);
                var response = client.PostAsync(url, content).Result;
                var data = response.Content.ReadAsStringAsync();
 
                txtOutput.Text += Environment.NewLine + $"The response is {data.Result}";
             }


            txtOutput.Text += "Clicked";

        }

        private void txtOutput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
