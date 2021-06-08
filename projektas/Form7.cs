using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace projektas
{
    public partial class Form7 : Form
    {
        private string userId;

        public Form7(string id)
        {
            InitializeComponent();

            this.userId = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new Form1(userId);
            this.Hide();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form = new Form3(userId);
            this.Hide();
            form.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            DialogResult alert = MessageBox.Show("Ar norite išeiti?", "Išeiti", MessageBoxButtons.YesNo);

            if (alert == DialogResult.Yes)
                Application.Exit();
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label5.ForeColor = Color.White;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Red;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form form = new Form8(userId);
            this.Hide();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form form = new Form9(userId);
            this.Hide();
            form.Show();
        }

       private void Form7_Load(object sender, EventArgs e)
        {
            MysqlDB sqlDb = new MysqlDB();

            IDictionary<string, string> servicesDataAndTime = sqlDb.getServicesData(userId);

            foreach (KeyValuePair<string, string> dataAndTime in servicesDataAndTime)
            {
                string dataShow = "";

                IDictionary<string, bool> servicesData = JsonConvert.DeserializeObject<Dictionary<string, bool>>(dataAndTime.Key);

                foreach (KeyValuePair<string, bool> data in servicesData)
                {
                    dataShow += data.Key;
                    dataShow += ", ";
                }

                string dateTime = dataAndTime.Value;

                dataShow += dateTime;

                listBox1.Items.Add(dataShow);
            }
        }
    }
}
