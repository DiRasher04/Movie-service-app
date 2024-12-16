using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Movie_service
{
    internal class ConnectionDB
    {
        public void InsertDB(string query)
        {
            string sqlConnection = "Server=localhost;Port=5432;Database=Movie_Service;User Id=postgres;Password=LeeKeyStone;";
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection(sqlConnection);
                conn.Open();
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public DataTable SelectDB(string query)
        {
            string sqlConnection = "Server = localhost; Port = 5432; Database = Movie_Service; User Id = postgres; Password = LeeKeyStone; ";
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection(sqlConnection);
                DataTable dataTable = new DataTable();
                conn.Open();
                using (var command = new NpgsqlCommand(query, conn))
                {
                    using (var adapter = new NpgsqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
                return dataTable;

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }
    }
}