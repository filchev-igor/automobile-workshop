using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projektas
{
    public partial class Form4 : Form
    {
        private string userId;
        private string dateTime;
        private IDictionary<string, bool> services;

        public Form4(string id, string dateTimeData, IDictionary<string, bool> data)
        {
            InitializeComponent();

            this.userId = id;
            this.dateTime = dateTimeData;
            this.services = data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new Form7(userId);
            this.Hide();
            form.Show();
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Red;
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label5.ForeColor = Color.White;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            DialogResult alert = MessageBox.Show("Do you wish to quit?", "Exit", MessageBoxButtons.YesNo);

            if (alert == DialogResult.Yes)
                Application.Exit();
        }
    }
}
