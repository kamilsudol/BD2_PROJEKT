using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace projectUDT_app
{
    public class DBConnection
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
                    }
                    Console.WriteLine();
                }
                if (flag) throw new ArgumentException("Brak danych!");
                
            }
            catch (SqlException e)
            {
                throw new ArgumentException(e.Message.Split('$')[1]);
            }
            finally
            {
                this.conn.Close();
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
            finally
            {
                this.conn.Close();
            }
        }

        public void DeleteQuery(string query)
        {
            try
            {
                this.conn.Open();
                SqlCommand c = new SqlCommand(query, this.conn);
                int reader = c.ExecuteNonQuery();
                if (reader != 0)
                {
                    throw new ArgumentException("Pomyslne usuniecie liczby rekordow: " + reader.ToString());
                }
                else {
                    throw new ArgumentException("Brak danych do usuniecia!");
                }
                
            }
            catch (SqlException e)
            {
                throw new ArgumentException(e.Message.Split('$')[1]);
            }
            finally {
                this.conn.Close();
            }
        }

        public List<string> ExecuteQuery(string query, List<string> attributes)
        {
            List<string> result = new List<string>();
            try
            {
                this.conn.Open();
                SqlCommand c = new SqlCommand(query, this.conn);
                SqlDataReader reader = c.ExecuteReader();

                bool flag = true;
                while (reader.Read())
                {
                    flag = false;
                    foreach (var element in attributes)
                    {
                        result.Add(reader[element].ToString());
                    }
                }
                if (flag) throw new ArgumentException("Brak danych!");

            }
            catch (SqlException e)
            {
                throw new ArgumentException(e.Message.Split('$')[1]);
            }
            finally
            {
                this.conn.Close();
            }
            return result;
        }
    }
}
