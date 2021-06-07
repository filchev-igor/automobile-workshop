﻿using MySql.Data.MySqlClient;
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
        Form1 frm1;
        Form4 frm4;

        private string email;

        public Form4(string username)
        {
            InitializeComponent();

            this.email = username;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            frm1 = new Form1(email);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new Form7(email);
            this.Hide();
            form.Show();
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = Color.White;
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Black;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


    }
}
