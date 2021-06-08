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
        private string userId;

        public Form9(string id)
        {
            InitializeComponent();

            this.userId = id;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            DialogResult alert = MessageBox.Show("Ar norite išeiti?", "Išeiti", MessageBoxButtons.YesNo);

            if (alert == DialogResult.Yes)
                Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form = new Form7(userId);
            this.Hide();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult isReadyToDelete = MessageBox.Show("Ar norite išeiti?", "Išeiti", MessageBoxButtons.YesNo);

            if (isReadyToDelete != DialogResult.Yes)
                return;

            MysqlDB sqlDb = new MysqlDB();

            bool isAccountDeleted = sqlDb.isAccountDeleted(userId);

            if (isAccountDeleted)
            {
                Form form = new Form5();
                this.Hide();
                form.Show();
            }
            else
            {
                MessageBox.Show("Įvyko klaida!");
            }
        }
    }
}
