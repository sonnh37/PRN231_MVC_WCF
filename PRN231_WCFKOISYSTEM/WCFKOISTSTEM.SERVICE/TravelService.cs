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

        public Travel GetTravelById(string id)
        {
            Travel travel = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT Id, Name, Location FROM Travel WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    travel = new Travel
                    {
                        Id = reader["Id"].ToString(),
                        Name = reader["Name"].ToString(),
                        Location = reader["Location"].ToString(),
                    };
                }
            }

            return travel;
        }

        public void CreateTravel(Travel travel)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Travel (Name, Location, IsDeleted) VALUES (@Name, @Location, @IsDeleted)", connection);
                command.Parameters.AddWithValue("@Name", travel.Name);
                command.Parameters.AddWithValue("@Location", travel.Location);
                command.Parameters.AddWithValue("@IsDeleted", false); 

                command.ExecuteNonQuery();
            }
        }

        public void UpdateTravel(Travel travel)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Travel SET Name = @Name, Location = @Location WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", travel.Id);
                command.Parameters.AddWithValue("@Name", travel.Name);
                command.Parameters.AddWithValue("@Location", travel.Location);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteTravel(string id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Travel WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }

}