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
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace purchaser_applic
{

    public partial class maincontent : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private const string apiKey = "0cd5f8e3fa7bf633759131d5"; // Replace with your actual API key
        private const string apiUrl = "https://v6.exchangerate-api.com/v6/0cd5f8e3fa7bf633759131d5/latest/USD";

        

        public maincontent()
        {
            InitializeComponent();
            LoadCurrencyData();
            radioButton1.Checked = false;
        }

        private async void LoadCurrencyData()
        {
            try
            {
                var response = await client.GetStringAsync(apiUrl);
                var data = JObject.Parse(response);
                var exchangeRates = data["conversion_rates"];

                var currencies = new string[] { "GBP", "VND", "MZN" };
                var displayData = new System.Text.StringBuilder();

                foreach (var currency in currencies)
                {
                    var exchangeRate = exchangeRates[currency].ToString();
                    displayData.AppendLine($"USD to {currency}: {exchangeRate}");
                }

                UpdateUI(displayData.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching currency data: " + ex.Message);
            }
        }

        private async void LoadGBPData()
        {
            try
            {
                var response = await client.GetStringAsync(apiUrl);
                var data = JObject.Parse(response);
                var exchangeRateUK = data["conversion_rates"]["EUR"].ToString(); // Example for USD to EUR
                UpdateUI(exchangeRateUK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching currency data: " + ex.Message);
            }
        }

        private void maincontent_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.succespn);
            player.Play();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string s1 = label1.Text;
            string s2 = s1.Substring(0,1);
            string s3 = s1.Substring(1, s1.Length - 1);
            string s4 = s3 + s2;
            label1.Text = s4;

            string s5 = label10.Text;
            string s6 = s5.Substring(0, 1);
            string s7 = s5.Substring(1, s5.Length - 1);
            string s8 = s7 + s6;
            label10.Text = s8;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void UpdateUI(string displayData)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(UpdateUI), new object[] { displayData });
                return;
            }

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
          
            
                label7.Text = "mozambican metical: $10000000000000000";
            
        }
         
        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("War Enabled, real life consequences!", "warns", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("War Enabled, real life consequences!", "warns", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.succespn);
            player.Play();

            MessageBox.Show("you have been automatically charged!!!1!! real purchase.!  ", "warns", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.succespn);
            player.Play();

            MessageBox.Show(" funds will be deposited sometimes soon probably  ", "warns", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
