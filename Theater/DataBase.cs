﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theater
{
    internal class DataBase
    {
        SqlConnection connection = new SqlConnection(@"Data Source=HOME-PC\SQLEXPRESS;Initial Catalog=Theater;Integrated Security=True");

        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            { connection.Open(); }
        }

        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            { connection.Close(); }
        }

        public SqlConnection GetConnection()
        {
            return connection;
        }
    }
}
