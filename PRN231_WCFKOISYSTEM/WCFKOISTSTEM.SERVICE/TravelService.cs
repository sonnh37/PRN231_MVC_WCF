using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace WCFKOISTSTEM.SERVICE
{
    public class TravelService
    {
        private string connectionString = "Data Source=.;Initial Catalog=FA24_SE1717_PRN231_G3_KOIORDERINGSYSTEMINJAPAN;Integrated Security=True;";

        public List<Travel> GetTravels()
        {
            var travels = new List<Travel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT Id, Name, Location FROM Travel", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    travels.Add(new Travel
                    {
                        Id = reader["Id"].ToString(),
                        Name = reader["Name"].ToString(),
                        Location = reader["Location"].ToString(),
                    });
                }
            }

            return travels;
        }
    }

}