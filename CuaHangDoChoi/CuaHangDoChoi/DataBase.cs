using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Tutorial.SqlConn
{
    class DataBase
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "127.0.0.1";
            int port = 3306;
            string database = "CuaHangDoChoi";
            string username = "root";
            string password = "1234";

            return ConnectionDATA.GetDBConnection(host, port, database, username, password);
        }

    }
}