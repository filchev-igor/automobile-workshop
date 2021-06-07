﻿using System;
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
    public partial class Form1 : Form
    {
        private string userId;
        
        public Form1(string id)
        {
            InitializeComponent();

            this.userId = id;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> servicesNames = new List<string>();
            List<bool> servicesValues = new List<bool>();

            foreach (Control c in this.Controls)
            {
                if (c is CheckBox)
                {
                    string checkboxName = c.Text;
                    bool checkboxState = ((CheckBox) c).Checked;

                    servicesNames.Add(checkboxName);
                    servicesValues.Add(checkboxState);
                }
            }

            Form form = new Form2(userId, servicesNames, servicesValues);
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
            Form form = new Form7(userId);
            this.Hide();
            form.Show();
        }
    }
}
