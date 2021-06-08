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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new Form5();
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
            string email = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();
            string passwordRepeat = textBox3.Text.Trim();
            string name = textBox4.Text.Trim();
            string surname = textBox5.Text.Trim();
            string phone = textBox7.Text.Trim();
            string carNumber = textBox8.Text.Trim();

            Fields checkFields = new Fields();

            bool isNotValidEmail = !checkFields.isValidEmail(email);
            bool isNotValidPassword = !checkFields.isValidPassword(password);
            bool isNotValidPasswordRepeat = !(password == passwordRepeat);
            bool isNotValidPhone = !checkFields.isValidPassword(phone);
            bool isNotValidCarNumber = !checkFields.isValidCarNumber(carNumber);

            label2.Text = "";

            if (isNotValidEmail || isNotValidPassword || isNotValidPasswordRepeat || isNotValidPhone || isNotValidCarNumber)
            {
                if (isNotValidEmail)
                    label2.Text += "Not valid email";

                if (isNotValidPassword)
                    label2.Text += "Password is too short";

                if (isNotValidPasswordRepeat)
                    label2.Text += "Passwords does not match";

                if (isNotValidPhone)
                    label2.Text += "Phone should contain numbers only (without +)";

                if (isNotValidCarNumber)
                    label2.Text += "Check the car number again";

                return;
            }
                        
            MysqlDB sqlDb = new MysqlDB();

            bool isRegistrationPossible = sqlDb.isRegistrationPossible(email, phone, carNumber);

            if (!isRegistrationPossible)
            {
                label2.Text = "Check email, phone or car number!";

                return;
            }

            string[] signInData = sqlDb.createUser(email, password, name, surname, phone, carNumber);

            bool isUserCreated = Convert.ToBoolean(signInData[0]);
            string userId = signInData[1];

            if (isUserCreated)
            {
                Form form = new Form7(userId);
                this.Hide();
                form.Show();
            }
        }
    }
}
