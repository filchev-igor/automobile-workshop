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
    public partial class Form9 : Form
    {
        private string email;

        public Form9(string username)
        {
            InitializeComponent();

            this.email = username;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            DialogResult alert = MessageBox.Show("Do you wish to quit?", "Exit", MessageBoxButtons.YesNo);

            if (alert == DialogResult.Yes)
                Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form = new Form7(email);
            this.Hide();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult isReadyToDelete = MessageBox.Show("Do you wish to quit?", "Exit", MessageBoxButtons.YesNo);

            if (isReadyToDelete != DialogResult.Yes)
                return;

            MysqlDB sqlDb = new MysqlDB();

            bool isAccountDeleted = sqlDb.isAccountDeleted(email);

            if (isAccountDeleted)
            {
                Form form = new Form5();
                this.Hide();
                form.Show();
            }
            else
            {
                MessageBox.Show("Something went wrong!");
            }
        }
    }
}
