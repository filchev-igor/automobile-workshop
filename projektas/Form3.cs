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
    public partial class Form3 : Form
    {
        private string email;

        public Form3(string username)
        {
            InitializeComponent();

            this.email = username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox2.Text.Trim();
            string name = textBox1.Text.Trim();
            string surname = textBox5.Text.Trim();
            string phone = textBox3.Text.Trim();
            string carNumber = textBox4.Text.Trim();

            Fields checkFields = new Fields();

            bool isNotValidEmail = !checkFields.isValidEmail(email);
            bool isNotValidPhone = !checkFields.isValidPassword(phone);
            bool isNotValidCarNumber = checkFields.isValidCarNumber(carNumber);

            label8.Text = "";

            if (isNotValidEmail || isNotValidPhone || isNotValidCarNumber)
            {
                if (isNotValidEmail)
                    label8.Text += "Not valid email";

                if (isNotValidPhone)
                    label8.Text += "Phone should contain numbers only (without +)";

                if (isNotValidCarNumber)
                    label8.Text += "Check the car number again";

                return;
            }

            bool isDataChanged = false;

            if (isDataChanged)
            {
                label8.Text = "Your data has been updated";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form = new Form7(email);
            this.Hide();
            form.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            DialogResult alert = MessageBox.Show("Do you wish to quit?", "Exit", MessageBoxButtons.YesNo);

            if (alert == DialogResult.Yes)
                Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            label6.ForeColor = Color.White;
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Red;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            MysqlDB sqlDb = new MysqlDB();

            string[] data = sqlDb.getPersonalData(email);

            textBox1.Text = data[0];
            textBox5.Text = data[1];
            textBox3.Text = data[2];
            textBox4.Text = data[3];
            textBox2.Text = email;
        }
    }
}
