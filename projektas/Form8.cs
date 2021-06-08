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
    public partial class Form8 : Form
    {
        private string userId;

        public Form8(string id)
        {
            InitializeComponent();

            this.userId = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string currentPassword = textBox1.Text.Trim();
            string newPassword = textBox5.Text.Trim();
            string passwordRepeat = textBox2.Text.Trim();

            Fields checkFields = new Fields();

            bool isCurrentPasswordNotValid = !checkFields.isValidPassword(currentPassword);
            bool isNewPasswordNotValid = !checkFields.isValidPassword(newPassword);
            bool isSamePassword = currentPassword == newPassword;
            bool isPasswordRepeatNotValid = newPassword != passwordRepeat;

            label8.Text = "";

            if (isCurrentPasswordNotValid || isNewPasswordNotValid || isSamePassword || isPasswordRepeatNotValid)
            {
                if (isCurrentPasswordNotValid)
                    label8.Text += "Not valid current password";

                if (isNewPasswordNotValid)
                    label8.Text += "Not valid new password";

                if (isSamePassword)
                    label8.Text += "Password should be new";

                if (isPasswordRepeatNotValid)
                    label8.Text += "Repeat the correct password";

                return;
            }

            MysqlDB sqlDb = new MysqlDB();

            bool isPasswordUpdated = sqlDb.isPasswordUpdated(userId, newPassword);

            if (isPasswordUpdated)
                label8.Text = "Your password has been updated";
            else
                label8.Text = "Check all your data again, please!";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form = new Form7(userId);
            this.Hide();
            form.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            DialogResult alert = MessageBox.Show("Do you wish to quit?", "Exit", MessageBoxButtons.YesNo);

            if (alert == DialogResult.Yes)
                Application.Exit();
        }
    }
}
