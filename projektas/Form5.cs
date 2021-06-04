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
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f4 = new Form4();
            this.Hide();
            f4.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form f6 = new Form6();
            this.Hide();
            f6.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Black;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = Color.White;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            
            String username = textBox2.Text;
            String password = textBox1.Text;

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();


            MySqlCommand command = new MySqlCommand("SELECT * FROM `vartotojai` WHERE `username`= @usn and `password`= @pass,", db.getConnection());

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;

            adapter.Fill(table);
            //check if the user exist or not
            if (table.Rows.Count > 0)
            {
                MessageBox.Show("TAIP");
            }
            else
            {
                if (username.Trim().Equals(""))
                {
                    MessageBox.Show("Tam, kad prisijungti, įveskite vartotojo vardą", "Neįvestas vartotojo vardas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (username.Trim().Equals(""))
                {
                    MessageBox.Show("Tam, kad prisijungti, įveskite slaptažodį", "Neįvestas slaptažodis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Neteisingas vartotojo vardas ar slaptažodis", "Neteisingi duomenys", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
