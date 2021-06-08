using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            DialogResult alert = MessageBox.Show("Do you wish to quit?", "Exit", MessageBoxButtons.YesNo);

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
            int dateRow = 0;

            MysqlDB sqlDb = new MysqlDB();

            IDictionary<string, string> servicesDataAndTime = sqlDb.getServicesData(userId);

            foreach (KeyValuePair<string, string> dataAndTime in servicesDataAndTime)
            {
                int dataRow = 0;

                Label dateLabel = new Label();

                IDictionary<string, bool> servicesData = JsonConvert.DeserializeObject<Dictionary<string, bool>>(dataAndTime.Key);

                foreach (KeyValuePair<string, bool> data in servicesData)
                {
                    Label label = new Label();

                    label.Text += data.Key;

                    tableLayoutPanel1.Controls.Add(label, 0, dataRow);

                    dataRow++;
                }
                
                string dateTime = dataAndTime.Value;

                dateLabel.Text = dateTime;

                tableLayoutPanel1.Controls.Add(dateLabel, 1, dateRow);

                dateRow += dateRow;
                dateRow++;
            }
        }
    }
}
