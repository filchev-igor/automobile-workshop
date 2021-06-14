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

            // Create an unbound DataGridView by declaring a
            // column count.
            dataGridView1.ColumnCount = 3;

            // Set the column header style.
            DataGridViewCellStyle columnHeaderStyle =
                new DataGridViewCellStyle();
            columnHeaderStyle.BackColor = Color.Aqua;
            columnHeaderStyle.Font =
                new Font("Verdana", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle =
                columnHeaderStyle;

            // Set the column header names.
            dataGridView1.Columns[0].Name = "Services";
            dataGridView1.Columns[1].Name = "Date";
            dataGridView1.Columns[2].Name = "Time";

            foreach (KeyValuePair<string, string> dataAndTime in servicesDataAndTime)
            {
                string list = "";

                IDictionary<string, bool> servicesData = JsonConvert.DeserializeObject<Dictionary<string, bool>>(dataAndTime.Key);

                foreach (KeyValuePair<string, bool> data in servicesData)
                {
                    list += data.Key;
                    list += Environment.NewLine;
                }

                string dateTime = dataAndTime.Value;

                string[] dateAndTime = dateTime.Split(' ');

                string[] loopRow = new string[] {list, dateAndTime[0], dateAndTime[1]};

                dataGridView1.Rows.Add(loopRow);
            }
        }
    }
}
