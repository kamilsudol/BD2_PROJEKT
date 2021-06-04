using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace projectUDT_app
{
    class DBConnection
    {
        private SqlConnection conn;
        private static string sqlconn_str;

        public DBConnection() {
        
            sqlconn_str = @"DATA SOURCE=MSSQLSERVER42; INITIAL CATALOG=PROJEKT_BD2; INTEGRATED SECURITY=SSPI;";
            conn = new SqlConnection(sqlconn_str);
        }

        public void SelectQuery(string query, List<string> attributes) {
            try
            {
                this.conn.Open();
                SqlCommand c = new SqlCommand(query, this.conn);
                SqlDataReader reader = c.ExecuteReader();

                bool flag = true;
                while (reader.Read()) {
                    flag = false;
                    foreach (var element in attributes) {
                        Console.WriteLine(reader[element].ToString());
                        //Console.Write("{0, -20} ", reader[element].ToString());
                    }
                    Console.WriteLine();
                }
                if (flag) throw new ArgumentException("Brak danych!");
                
            }
            catch (SqlException e)
            {
                throw new ArgumentException(e.Message.Split('$')[1]);
            }
        }

        public void InsertQuery(string query)
        {
            try {
                this.conn.Open();
                SqlCommand c = new SqlCommand(query, this.conn);
                SqlDataReader reader = c.ExecuteReader();
                throw new ArgumentException("Pomyslnie wprowadzono nowe dane!");
            }
            catch(SqlException e) {
                throw new ArgumentException(e.Message.Split('$')[1]);
            }
        }

        public void DeleteQuery(string query)
        {
            try
            {
                this.conn.Open();
                SqlCommand c = new SqlCommand(query, this.conn);
                SqlDataReader reader = c.ExecuteReader();
                throw new ArgumentException("Pomyslnie usunieto dane!");
            }
            catch (SqlException e)
            {
                throw new ArgumentException(e.Message.Split('$')[1]);
            }
        }
    }
}
