using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projektas
{
    class MysqlDB
    {
        private const string connectionString = "server=localhost;port=3306;username=root;password=;database=customers";

        private MySqlConnection getConnection()
        {
            MySqlConnection connection = null;

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
            }

            return connection;
        }

        public bool isRegistrationPossible(string email, string phone, string carNumber)
        {
            bool returnValue = false;

            MySqlConnection connection = this.getConnection();

            string sql = "SELECT * FROM users WHERE email=@email OR phone=@phone OR carNumber=@carNumber";

            MySqlCommand command = new MySqlCommand(sql, connection);

            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@carNumber", MySqlDbType.VarChar).Value = carNumber;

            object result = command.ExecuteScalar();
            int rows = Convert.ToInt32(result);

            if (rows == 0)
                returnValue = true;

            connection.Close();

            return returnValue;
        }

        public bool createUser(string email, string password, string name, string surname, string phone, string carNumber)
        {
            bool returnValue = false;

            MySqlConnection connection = this.getConnection();

            string sql = "INSERT INTO users(email, password, name, surname, phone, carNumber) VALUES (@email, @password, @name, @surname, @phone, @carNumber)";

            MySqlCommand command = new MySqlCommand(sql, connection);

            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = surname;
            command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@carNumber", MySqlDbType.VarChar).Value = carNumber;

            if (command.ExecuteNonQuery() == 1)
                returnValue = true;

            connection.Close();

            return returnValue;
        }

        public bool isSignInPossible(string email, string password)
        {
            bool returnValue = false;

            MySqlConnection connection = this.getConnection();

            string sql = "SELECT * FROM users WHERE email=@email AND password=@password";

            MySqlCommand command = new MySqlCommand(sql, connection);

            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;

            object result = command.ExecuteScalar();
            int rows = Convert.ToInt32(result);

            if (rows > 0)
                returnValue = true;

            connection.Close();

            return returnValue;
        }

        public void getPersonalData()
        {

        }
    }
}
