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
        private string userId;

        public Form3(string id)
        {
            InitializeComponent();

            this.userId = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox2.Text.Trim();
            string name = textBox1.Text.Trim();
            string surname = textBox5.Text.Trim();
            string phone = textBox3.Text.Trim();
            string carNumber = textBox4.Text.Trim();
            string password = textBox6.Text.Trim();

            Fields checkFields = new Fields();

            bool isNotValidEmail = !checkFields.isValidEmail(email);
            bool isNotValidPhone = !checkFields.isValidPassword(phone);
            bool isNotValidCarNumber = !checkFields.isValidCarNumber(carNumber);
            bool isNotValidPassword = !checkFields.isValidPassword(password);

            label3.Text = "";

            if (isNotValidEmail || isNotValidPhone || isNotValidCarNumber || isNotValidPassword)
            {
                if (isNotValidEmail)
                    label3.Text += "Neteisingas el. paštas";

                if (isNotValidPhone)
                    label3.Text += "Tel. numeris turi būti sudarytas tik iš skaičių (be +)";

                if (isNotValidCarNumber)
                    label3.Text += "Patikrinti automobilio numerį";

                if (isNotValidPassword)
                    label3.Text += "Patikrinti slaptažodį";

                return;
            }

            MysqlDB sqlDb = new MysqlDB();
            
            bool isDataChangeAllowed = sqlDb.isDataChangeAllowed(email, phone, carNumber, userId);

            if (!isDataChangeAllowed)
            {
                label3.Text = "El. paštas, telefono ar automobilio numeriai jau egzistuoja";

                return;
            }
          
            bool isDataUpdated = sqlDb.isDataUpdated(email, name, surname, phone, carNumber, password, userId);

            if (isDataUpdated)
                label3.Text = "Jūsų duomenys buvo atnaujinti";
            else
                label3.Text = "Dar kartą patikrinkite savo duomenis";
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

            string[] data = sqlDb.getPersonalData(userId);

            textBox1.Text = data[1];
            textBox5.Text = data[2];
            textBox3.Text = data[3];
            textBox4.Text = data[4];
            textBox2.Text = data[0];
        }
    }
}
