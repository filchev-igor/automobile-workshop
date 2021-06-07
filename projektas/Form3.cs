﻿using System;
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
            bool isDataChanged = false;

            if (isDataChanged)
            {
                
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
                this.Close();
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label5.ForeColor = Color.White;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Red;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Black;
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            label6.ForeColor = Color.White;
        }
    }
}
