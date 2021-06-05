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

        public void createUser()
        {
            MySqlConnection connection = this.getConnection();

            MySqlCommand command = new MySqlCommand("INSERT INTO `users`(`email`, `password`, `name`, `surname`, `phone`, `carNumber`) VALUES (@email, @password, @name, @surname, @phone, @carNumber)", connection);

            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = "user@user.com";
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = "No";
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = "Axel";
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = "Foley";
            command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = "+3764097864";
            command.Parameters.Add("@carNumber", MySqlDbType.VarChar).Value = "AAA1111";


            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Your Account Has Been Created", "Account Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
             else
                MessageBox.Show("ERROR");

            connection.Close();
        }
    }
}
