using MySql.Data.MySqlClient;
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
    public partial class Form2 : Form
    {
        private string userId;
        IDictionary<string, bool> services;

        public Form2(string id, IDictionary<string, bool> data)
        {
            InitializeComponent();

            this.userId = id;
            this.services = data;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form = new Form1(userId);
            this.Hide();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dateTime = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd HH:mm");

            MysqlDB sqlDb = new MysqlDB();

            bool isNewServiceAdded = sqlDb.isNewServiceAdded(userId, dateTime, services);

            if (isNewServiceAdded)
            {
                Form form = new Form4(userId, dateTime, services);
                this.Hide();
                form.Show();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            DialogResult alert = MessageBox.Show("Do you wish to quit?", "Exit", MessageBoxButtons.YesNo);

            if (alert == DialogResult.Yes)
                Application.Exit();
        }
    }
}
