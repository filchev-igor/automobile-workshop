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

        private void button1_Click(object sender, EventArgs e)
        {
            Form f5 = new Form5();
            this.Hide();
            f5.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new Form5();
            this.Hide();
            form.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Black;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = Color.White;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            String fname = textBox1.Text;
            if (fname.ToLower().Trim().Equals("first name"))
            {
                textBox1.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            String fname = textBox1.Text;
            if (fname.ToLower().Trim().Equals("first name") || fname.Trim().Equals(""))
            {
                textBox1.Text = "first name";
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            String lname = textBox1.Text;
            if (lname.ToLower().Trim().Equals("last name"))
            {
                textBox2.Text = "";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            String lname = textBox1.Text;
            if (lname.ToLower().Trim().Equals("last name") || lname.Trim().Equals(""))
            {
                textBox2.Text = "last name";
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            String email = textBox3.Text;
            if (email.ToLower().Trim().Equals("email"))
            {
                textBox3.Text = "";
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            String email = textBox3.Text;
            if (email.ToLower().Trim().Equals("email") || email.Trim().Equals(""))
            {
                textBox3.Text = "email";
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            String username = textBox4.Text;
            if (username.ToLower().Trim().Equals("username"))
            {
                textBox4.Text = "";
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            String username = textBox4.Text;
            if (username.ToLower().Trim().Equals("username") || username.Trim().Equals(""))
            {
                textBox4.Text = "email";
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            String password = textBox5.Text;
            if (password.ToLower().Trim().Equals("password"))
            {
                textBox5.Text = "";
                textBox5.UseSystemPasswordChar = true;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            String password = textBox5.Text;
            if (password.ToLower().Trim().Equals("password") || password.Trim().Equals(""))
            {
                textBox5.Text = "password";
                textBox5.UseSystemPasswordChar = false;
            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            /*
            String cpassword = textBox6.Text;
            if (cpassword.ToLower().Trim().Equals("confirm password"))
            {
                textBox6.Text = "";
                textBox6.UseSystemPasswordChar = true;
            }
            */
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            /*
            String cpassword = textBox6.Text;
            if (cpassword.ToLower().Trim().Equals("confirm password") ||
                cpassword.ToLower().Trim().Equals("password") ||
                cpassword.Trim().Equals(""))
            {
                textBox6.Text = "confirm password";
                textBox6.UseSystemPasswordChar = false;
            }
            */
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MysqlDB sqlDb = new MysqlDB();

            sqlDb.createUser();

            bool isUserCreated = false;

            if (isUserCreated)
            {
                Form form = new Form7();
                this.Hide();
                form.Show();
            }
        }

        //check if the username already exist
        public Boolean checkUsername()
        {
            DB db = new DB();
            String username = textBox2.Text;
            

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();


            MySqlCommand command = new MySqlCommand("SELECT * FROM `vartotojai` WHERE `username`= @usn", db.getConnection());

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
            

            adapter.SelectCommand = command;

            adapter.Fill(table);
            //check if this user already exist in the db
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

            
        }



        //check if the textboxes contain the deault values
        public Boolean checkTexBoxesValues()
        {
            String fname = textBox1.Text;
            String lname = textBox2.Text;
            String email = textBox3.Text;
            String uname = textBox4.Text;
            String pass = textBox5.Text;
            if(fname.Equals("first name") || lname.Equals("last name") || email.Equals("email asddress") || uname.Equals("username") || pass.Equals("password"))
            {
                return true;
            }
              else
            { 
            return false;
            }
                    
        }
    }
}
