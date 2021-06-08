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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();

            this.textBox2.AutoSize = false;
            this.textBox2.Size = new Size(this.textBox2.Size.Width, 50);

            Fields fields = new Fields();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new Form6();
            this.Hide();
            form.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
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
            string email = textBox2.Text.Trim();
            string password = textBox1.Text.Trim();

            Fields checkFields = new Fields();

            bool isNotValidEmail = !checkFields.isValidEmail(email);
            bool isNotValidPassword = !checkFields.isValidPassword(password);

            label2.Text = "";


            if (isNotValidEmail || isNotValidPassword)
            {
                if (isNotValidEmail)
                    label2.Text += "Not valid email";

                if (isNotValidPassword)
                    label2.Text += "Password is too short";

                return;
            }

            MysqlDB sqlDb = new MysqlDB();

            string[] logInData = sqlDb.isSignInPossible(email, password);

            bool isLogInPossible = Convert.ToBoolean(logInData[0]);
            string userId = logInData[1];

            if (!isLogInPossible)
            {
                label2.Text = "Check email or password!";

                return;
            }
            else
            {
                Form form = new Form7(userId);
                this.Hide();
                form.Show();
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (!(textBox1.TextLength > 0))
            {
                textBox1.Text = "slaptažodis";
                textBox1.UseSystemPasswordChar = false;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (!(textBox1.TextLength > 0) || textBox1.Text == "slaptažodis")
            {
                textBox1.Text = "";
                textBox1.UseSystemPasswordChar = true;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "vartotojo vardas")
            {
                textBox2.Text = "";
            }

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (!(textBox2.TextLength > 0))
            {
                textBox2.Text = "vartotojo vardas";
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
