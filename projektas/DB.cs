
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace projektas
{
    
    class DB
    {
       MySqlConnection connection = new MySqlConnection("server=localhost:8080;port=3306;username=root;password=;database=autoserviso_login");

        public void openConnection()
        {

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void closeConnection()
        {

            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public MySqlConnection getConnection()
        {
            return connection;
        }

    }

}
