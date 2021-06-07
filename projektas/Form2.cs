using MySql.Data.MySqlClient;
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
        List<string> servicesNames;
        List<bool> servicesValues;

        public Form2(string id, List<string> checkboxNames, List<bool> checkboxValues)
        {
            InitializeComponent();

            this.userId = id;
            this.servicesNames = checkboxNames;
            this.servicesValues = checkboxValues;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form = new Form1(userId);
            this.Hide();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Convert.ToString(dateTimePicker1.Value));

            return;

            Form form = new Form4(userId);
            this.Hide();
            form.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            DialogResult alert = MessageBox.Show("Do you wish to quit?", "Exit", MessageBoxButtons.YesNo);

            if (alert == DialogResult.Yes)
                Application.Exit();
        }
    }
}
