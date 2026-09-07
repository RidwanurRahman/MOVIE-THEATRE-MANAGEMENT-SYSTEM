using System;
using System.Data;
using System.Data.SqlClient;

namespace Movie_Theater_Management_System
{
    public class DataAccess
    {
        private readonly string conStr =
    @"Data Source=localhost;Initial Catalog=MTMS;Integrated Security=True;TrustServerCertificate=True;Connect Timeout=30";

        public DataTable ExecuteQuery(string query)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            con.Open();
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Query Error: " + ex.Message);
            }

            return dt;
        }

        public int ExecuteDML(string query)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("DML Error: " + ex.Message);
            }
        }
    }
}