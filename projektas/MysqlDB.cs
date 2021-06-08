using MySqlConnector;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projektas
{
    class MysqlDB
    {
        private const string connectionString = "server=localhost;port=3306;username=root;password=;database=customers; convert zero datetime=True";

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

        public string[] createUser(string email, string password, string name, string surname, string phone, string carNumber)
        {            
            string userId = "";
            string[] returnValue = {"false", userId};

            string encodedPassword = this.getHashedPassword(password);

            MySqlConnection connection = this.getConnection();

            string sql = "INSERT INTO users(email, password, name, surname, phone, carNumber) VALUES (@email, @password, @name, @surname, @phone, @carNumber)";

            MySqlCommand command = new MySqlCommand(sql, connection);

            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@password", MySqlDbType.LongText).Value = encodedPassword;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = surname;
            command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@carNumber", MySqlDbType.VarChar).Value = carNumber;

            if (command.ExecuteNonQuery() == 1)
            {
                returnValue[0] = "true";
                returnValue[1] = Convert.ToString(command.LastInsertedId);
            }

            connection.Close();

            return returnValue;
        }

        public string[] isSignInPossible(string email, string password)
        {
            string userId = "";
            int rows = 0;

            string[] returnValue = {"false", userId};

            string encodedPassword = this.getHashedPassword(password);

            MySqlConnection connection = this.getConnection();

            string sql = "SELECT COUNT(*) AS count, id FROM users WHERE email=@email AND password=@password";

            MySqlCommand command = new MySqlCommand(sql, connection);

            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@password", MySqlDbType.LongText).Value = encodedPassword;

            MySqlDataReader rdr = command.ExecuteReader();

            while (rdr.Read())
            {
                rows = Convert.ToInt32(rdr["count"]);
                userId = Convert.ToString(rdr["id"]);
            }

            if (rows > 0) {
                returnValue[0] = "true";
                returnValue[1] = userId;
            }

            connection.Close();

            return returnValue;
        }

        public string[] getPersonalData(string userId)
        {
            string[] data = new string[5];

            MySqlConnection connection = this.getConnection();

            string sql = "SELECT email, name, surname, phone, carNumber FROM users WHERE id=@userId LIMIT 0, 1";

            MySqlCommand command = new MySqlCommand(sql, connection);

            command.Parameters.Add("@userId", MySqlDbType.VarChar).Value = userId;

            MySqlDataReader rdr = command.ExecuteReader();

            while (rdr.Read())
            {
                data[0] = Convert.ToString(rdr["email"]);
                data[1] = Convert.ToString(rdr["name"]);
                data[2] = Convert.ToString(rdr["surname"]);
                data[3] = Convert.ToString(rdr["phone"]);
                data[4] = Convert.ToString(rdr["carNumber"]);
            }

            connection.Close();

            return data;
        }

        public bool isDataChangeAllowed(string email, string phone, string carNumber, string userId)
        {
            bool returnValue = true;

            MySqlConnection connection = this.getConnection();

            string sql = "SELECT * FROM users WHERE (email=@email OR phone=@phone ) AND id!=@userId";

            MySqlCommand command = new MySqlCommand(sql, connection);

            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@carNumber", MySqlDbType.VarChar).Value = carNumber;
            command.Parameters.Add("@userId", MySqlDbType.VarChar).Value = userId;

            object result = command.ExecuteScalar();
            int rows = Convert.ToInt32(result);

            if (rows > 0)
                returnValue = false;

            connection.Close();

            return returnValue;
        }

        public bool isDataUpdated(string email, string name, string surname, string phone, string carNumber, string password, string userId)
        {
            bool returnValue = false;

            string encodedPassword = this.getHashedPassword(password);

            MySqlConnection connection = this.getConnection();

            string sql = "UPDATE users " +
                "SET " +
                "email=@email, name=@name, surname=@surname, phone=@phone, carNumber=@carNumber " +
                "WHERE password=@password AND id=@userId";

            MySqlCommand command = new MySqlCommand(sql, connection);

            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = surname;
            command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@carNumber", MySqlDbType.VarChar).Value = carNumber;
            command.Parameters.Add("@password", MySqlDbType.LongText).Value = encodedPassword;
            command.Parameters.Add("@userId", MySqlDbType.LongText).Value = userId;

            if (command.ExecuteNonQuery() == 1)
                returnValue = true;

            connection.Close();

            return returnValue;
        }

        public bool isPasswordUpdated(string userId, string password)
        {
            bool returnValue = false;

            string encodedPassword = this.getHashedPassword(password);

            MySqlConnection connection = this.getConnection();

            string sql = "UPDATE users " +
                "SET " +
                "password=@password" +
                "WHERE id=@userId AND password=@password";

            MySqlCommand command = new MySqlCommand(sql, connection);

            command.Parameters.Add("@userId", MySqlDbType.VarChar).Value = userId;
            command.Parameters.Add("@password", MySqlDbType.LongText).Value = encodedPassword;

            if (command.ExecuteNonQuery() == 1)
                returnValue = true;

            connection.Close();

            return returnValue;
        }

        private string getHashedPassword(string password)
        {
            // byte array representation of that string
            byte[] encodedPassword = new UTF8Encoding().GetBytes(password);

            // need MD5 to calculate the hash
            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);

            // string representation (similar to UNIX format)
            string encoded = BitConverter.ToString(hash)
               // without dashes
               .Replace("-", string.Empty)
               // make lowercase
               .ToLower();

            return encoded;
        }

        public bool isAccountDeleted(string userId)
        {
            bool returnValue = false;

            MySqlConnection connection = this.getConnection();

            string sql = "DELETE FROM users " +
                "WHERE id=@userId";

            MySqlCommand command = new MySqlCommand(sql, connection);

            command.Parameters.Add("@userId", MySqlDbType.VarChar).Value = userId;

            if (command.ExecuteNonQuery() == 1)
                returnValue = true;

            connection.Close();

            return returnValue;
        }

        public bool isNewServiceAdded(string userId, string dateTime, IDictionary<string, bool> services)
        {
            bool returnValue = false;

            MySqlConnection connection = this.getConnection();

            string jsonString = JsonConvert.SerializeObject(services);

            string sql = "INSERT INTO services(userId, typeOfService, dateTime) VALUES (@userId, @typeOfService, @dateTime)";

            MySqlCommand command = new MySqlCommand(sql, connection);

            command.Parameters.Add("@userId", MySqlDbType.VarChar).Value = userId;
            command.Parameters.Add("@typeOfService", MySqlDbType.LongText).Value = jsonString;
            command.Parameters.Add("@dateTime", MySqlDbType.DateTime).Value = dateTime;
            
            if (command.ExecuteNonQuery() == 1)
                returnValue = true;

            connection.Close();

            return returnValue;
        }

        public IDictionary<string, string> getServicesData(string userId)
        {
            IDictionary<string, string> data = new Dictionary<string, string>();

            MySqlConnection connection = this.getConnection();

            string sql = "SELECT typeOfService, dateTime FROM services WHERE userId=@userId";

            MySqlCommand command = new MySqlCommand(sql, connection);

            command.Parameters.Add("@userId", MySqlDbType.VarChar).Value = userId;

            MySqlDataReader rdr = command.ExecuteReader();

            while (rdr.Read())
                data.Add(Convert.ToString(rdr["typeOfService"]), Convert.ToString(rdr["dateTime"]));

            connection.Close();

            return data;
        }
    }
}
