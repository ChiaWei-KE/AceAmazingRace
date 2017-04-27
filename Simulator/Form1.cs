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
        private static string _baseUrl;

        public Form1()
        {
            InitializeData();
            InitializeComponent();
            IntializeFormData();
        }

        public void IntializeFormData()
        {
            txtURL.Text = _baseUrl;
        }

        private void InitializeData()
        {
            _sampleLiveData = new List<List<RealTimeData>>()
            {
                new List<RealTimeData>() { new RealTimeData(1, 1.300029, 103.855058), new RealTimeData(2, 1.300029, 103.855058), new RealTimeData(3, 1.299129, 103.854168), new RealTimeData(4, 1.297542, 103.854216)},
                new List<RealTimeData>() { new RealTimeData(1, 1.30005, 103.85518), new RealTimeData(2, 1.29991, 103.85498), new RealTimeData(3, 1.29886, 103.85426), new RealTimeData(4, 1.29791, 103.8542)},
                new List<RealTimeData>() { new RealTimeData(1, 1.30026, 103.85538), new RealTimeData(2, 1.29975, 103.85496), new RealTimeData(3, 1.29857, 103.85434), new RealTimeData(4, 1.29839, 103.85419)},
                new List<RealTimeData>() { new RealTimeData(1, 1.30065, 103.85575), new RealTimeData(2, 1.29959, 103.85483), new RealTimeData(3, 1.29828, 103.85414), new RealTimeData(4, 1.29866, 103.85439)},
                new List<RealTimeData>() { new RealTimeData(1, 1.30082, 103.85587), new RealTimeData(2, 1.29939, 103.85469), new RealTimeData(3, 1.2981, 103.85435), new RealTimeData(4, 1.29883, 103.85422)},
                new List<RealTimeData>() { new RealTimeData(1, 1.30071, 103.85603), new RealTimeData(2, 1.29915, 103.85449), new RealTimeData(3, 1.29798, 103.85428), new RealTimeData(4, 1.299129, 103.854168)},
                new List<RealTimeData>() { new RealTimeData(1, 1.30061, 103.85616), new RealTimeData(2, 1.29904, 103.85439), new RealTimeData(3, 1.29786, 103.85425), new RealTimeData(4, 1.29924, 103.85442)},
                new List<RealTimeData>() { new RealTimeData(1, 1.300753, 103.856267), new RealTimeData(2, 1.299129, 103.854168), new RealTimeData(3, 1.29779, 103.85421), new RealTimeData(4, 1.29946, 103.85478)},
                new List<RealTimeData>() { new RealTimeData(1, 1.30057, 103.85625), new RealTimeData(2, 1.29895, 103.85426), new RealTimeData(3, 1.29771, 103.85419), new RealTimeData(4, 1.29987, 103.85513)},
                new List<RealTimeData>() { new RealTimeData(1, 1.29998, 103.85657), new RealTimeData(2, 1.29881, 103.85422), new RealTimeData(3, 1.297542, 103.854216), new RealTimeData(4, 1.300029, 103.855058)},
                new List<RealTimeData>() { new RealTimeData(1, 1.2997, 103.85655), new RealTimeData(2, 1.29866, 103.85409), new RealTimeData(3, 1.29748, 103.85439), new RealTimeData(4, 1.30042, 103.85554)},
                new List<RealTimeData>() { new RealTimeData(1, 1.29946, 103.8564), new RealTimeData(2, 1.29852, 103.85424), new RealTimeData(3, 1.29743, 103.85455), new RealTimeData(4, 1.30071, 103.85585)},
                new List<RealTimeData>() { new RealTimeData(1, 1.29919, 103.85623), new RealTimeData(2, 1.29829, 103.85411), new RealTimeData(3, 1.29735, 103.85471), new RealTimeData(4, 1.3007, 103.85608)},
                new List<RealTimeData>() { new RealTimeData(1, 1.2989, 103.85599), new RealTimeData(2, 1.29799, 103.85422), new RealTimeData(3, 1.29732, 103.85485), new RealTimeData(4, 1.300753, 103.856267)},
                new List<RealTimeData>() { new RealTimeData(1, 1.29865, 103.85582), new RealTimeData(2, 1.2979, 103.8542), new RealTimeData(3, 1.29748, 103.85496), new RealTimeData(4, 1.30034, 103.85628)},
                new List<RealTimeData>() { new RealTimeData(1, 1.298154, 103.855611), new RealTimeData(2, 1.29779, 103.85422), new RealTimeData(3, 1.29764, 103.85509), new RealTimeData(4, 1.29998, 103.85659)},
                new List<RealTimeData>() { new RealTimeData(1, 1.29799, 103.85543), new RealTimeData(2, 1.29772, 103.85419), new RealTimeData(3, 1.29778, 103.85518), new RealTimeData(4, 1.29976, 103.85653)},
                new List<RealTimeData>() { new RealTimeData(1, 1.29795, 103.8551), new RealTimeData(2, 1.297542, 103.854216), new RealTimeData(3, 1.29791, 103.85527), new RealTimeData(4, 1.29953, 103.85637)},
                new List<RealTimeData>() { new RealTimeData(1, 1.2977, 103.8548), new RealTimeData(2, 1.29757, 103.85435), new RealTimeData(3, 1.29808, 103.85537), new RealTimeData(4, 1.2993, 103.85623)},
                new List<RealTimeData>() { new RealTimeData(1, 1.29762, 103.8546), new RealTimeData(2, 1.29772, 103.85471), new RealTimeData(3, 1.298154, 103.855611), new RealTimeData(4, 1.29896, 103.85598)},
                new List<RealTimeData>() { new RealTimeData(1, 1.29757, 103.85437), new RealTimeData(2, 1.29767, 103.85492), new RealTimeData(3, 1.29864, 103.85577), new RealTimeData(4, 1.29874, 103.85582)},
                new List<RealTimeData>() { new RealTimeData(1, 1.297542, 103.854216), new RealTimeData(2, 1.29778, 103.85507), new RealTimeData(3, 1.29911, 103.85608), new RealTimeData(4, 1.29856, 103.85573)},
                new List<RealTimeData>() { new RealTimeData(1, 1.29773, 103.85421), new RealTimeData(2, 1.29787, 103.85525), new RealTimeData(3, 1.29939, 103.85629), new RealTimeData(4, 1.29842, 103.85565)},
                new List<RealTimeData>() { new RealTimeData(1, 1.298, 103.85419), new RealTimeData(2, 1.29808, 103.85537), new RealTimeData(3, 1.29965, 103.85647), new RealTimeData(4, 1.298154, 103.855611)},
                new List<RealTimeData>() { new RealTimeData(1, 1.29833, 103.85418), new RealTimeData(2, 1.29822, 103.8555), new RealTimeData(3, 1.29989, 103.85662), new RealTimeData(4, 1.298154, 103.855611)},
                new List<RealTimeData>() { new RealTimeData(1, 1.2987, 103.85411), new RealTimeData(2, 1.298154, 103.855611), new RealTimeData(3, 1.30015, 103.8565), new RealTimeData(4, 1.298154, 103.855611)},
                new List<RealTimeData>() { new RealTimeData(1, 1.29887, 103.85423), new RealTimeData(2, 1.29839, 103.8556), new RealTimeData(3, 1.30039, 103.8563), new RealTimeData(4, 1.298154, 103.855611)},
                new List<RealTimeData>() { new RealTimeData(1, 1.29896, 103.85424), new RealTimeData(2, 1.29868, 103.85577), new RealTimeData(3, 1.30057, 103.8562), new RealTimeData(4, 1.298154, 103.855611)},
                new List<RealTimeData>() { new RealTimeData(1, 1.29901, 103.85416), new RealTimeData(2, 1.29887, 103.85599), new RealTimeData(3, 1.300753, 103.856267), new RealTimeData(4, 1.298154, 103.855611)},
                new List<RealTimeData>() { new RealTimeData(1, 1.29907, 103.8541), new RealTimeData(2, 1.2991, 103.8561), new RealTimeData(3, 1.3007, 103.85603), new RealTimeData(4, 1.298154, 103.855611)},
                new List<RealTimeData>() { new RealTimeData(1, 1.29909, 103.85414), new RealTimeData(2, 1.29933, 103.85625), new RealTimeData(3, 1.30075, 103.85583), new RealTimeData(4, 1.298154, 103.855611)},
                new List<RealTimeData>() { new RealTimeData(1, 1.299129, 103.854168), new RealTimeData(2, 1.29965, 103.85646), new RealTimeData(3, 1.3006, 103.85571), new RealTimeData(4, 1.298154, 103.855611)},
                new List<RealTimeData>() { new RealTimeData(1, 1.299129, 103.854168), new RealTimeData(2, 1.2999, 103.85663), new RealTimeData(3, 1.30046, 103.85559), new RealTimeData(4, 1.298154, 103.855611)},
                new List<RealTimeData>() { new RealTimeData(1, 1.299129, 103.854168), new RealTimeData(2, 1.30005, 103.85658), new RealTimeData(3, 1.30034, 103.85549), new RealTimeData(4, 1.298154, 103.855611)},
                new List<RealTimeData>() { new RealTimeData(1, 1.299129, 103.854168), new RealTimeData(2, 1.30024, 103.8564), new RealTimeData(3, 1.30025, 103.85539), new RealTimeData(4, 1.298154, 103.855611)},
                new List<RealTimeData>() { new RealTimeData(1, 1.299129, 103.854168), new RealTimeData(2, 1.30046, 103.85622), new RealTimeData(3, 1.30013, 103.85528), new RealTimeData(4, 1.298154, 103.855611)},
                new List<RealTimeData>() { new RealTimeData(1, 1.299129, 103.854168), new RealTimeData(2, 1.30062, 103.85626), new RealTimeData(3, 1.300029, 103.855058), new RealTimeData(4, 1.298154, 103.855611)},
                new List<RealTimeData>() { new RealTimeData(1, 1.299129, 103.854168), new RealTimeData(2, 1.300753, 103.856267), new RealTimeData(3, 1.300029, 103.855058), new RealTimeData(4, 1.298154, 103.855611)}
            };

            _total = _sampleLiveData.Count;
            _counter = 0;
            _baseUrl = "http://localhost:50842";
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (_counter >= _sampleLiveData.Count) return;

            var myContent = JsonConvert.SerializeObject(new
            {
                LiveData = _sampleLiveData[_counter],
                ResetGame = false
            });
            
            using (var client = new HttpClient()) {

                try
                {
                    btnSend.Enabled = false;
                    btnResetLocations.Enabled = false;

                    client.BaseAddress = new Uri(txtURL.Text);

                    var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


                    var response = client.PostAsync("api/common/simulate", byteContent).Result;
                    var data = response.Content.ReadAsStringAsync();

                    txtOutput.Text = $@"{DateTime.Now} - {data.Result}" + Environment.NewLine + txtOutput.Text;
                    UpdateStat();
                    _counter++;
                }
                catch (Exception exception)
                {
                    txtOutput.Text = $@"{DateTime.Now} - Error found: {exception.Message}" + Environment.NewLine +txtOutput.Text;
                }
                finally
                {
                    btnSend.Enabled = true;
                    btnResetLocations.Enabled = true;
                }
            }

        }

        private void btnResetLocations_Click(object sender, EventArgs e)
        {
            var myContent = JsonConvert.SerializeObject(new
            {
                LiveData = new List<List<RealTimeData>>(),
                ResetGame = true
            });

            using (var client = new HttpClient())
            {

                try
                {
                    client.BaseAddress = new Uri(txtURL.Text);

                    var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


                    var response = client.PostAsync("api/common/simulate", byteContent).Result;
                    var data = response.Content.ReadAsStringAsync();

                    txtOutput.Text = $@"{DateTime.Now} - Reset Game" + Environment.NewLine + txtOutput.Text;
                    _counter = 0;
                    lblSteps.Text = "";
                }
                catch (Exception exception)
                {
                    txtOutput.Text = $@"{DateTime.Now} - Error found: {exception.Message}" + Environment.NewLine +
                                     txtOutput.Text;
                }
            }
            
        }

        private void UpdateStat()
        {
            lblSteps.Text = $@"{_counter + 1:00}/{_total:00}";
        }

        private void txtURL_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtOutput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
