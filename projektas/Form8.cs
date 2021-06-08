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
                    label8.Text += "Neteisingas dabartinis slaptažodis";

                if (isNewPasswordNotValid)
                    label8.Text += "Neteisingas naujas slaptažodis";

                if (isSamePassword)
                    label8.Text += "Naudoti tik naują slaptažodį";

                if (isPasswordRepeatNotValid)
                    label8.Text += "Pakartotinai įveskite teisingą slaptažodį";

                return;
            }

            MysqlDB sqlDb = new MysqlDB();

            bool isPasswordUpdated = sqlDb.isPasswordUpdated(userId, newPassword);

            if (isPasswordUpdated)
                label8.Text = "Jūsų slaptažodis buvo atnaujintas";
            else
                label8.Text = "Dar karta patikrinkite visus jūsų duomenis!";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form = new Form7(userId);
            this.Hide();
            form.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            DialogResult alert = MessageBox.Show("Ar norite išeiti?", "Išeiti", MessageBoxButtons.YesNo);

            if (alert == DialogResult.Yes)
                Application.Exit();
        }
    }
}
