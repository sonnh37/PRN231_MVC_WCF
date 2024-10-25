using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Net1711_231_ASM4_SE172092_NGUYENHOANGSON.Service
{
    public class TravelService
    {
        private readonly string connectionString =
            "Data Source=.;Initial Catalog=FA24_SE1717_PRN231_G3_KOIORDERINGSYSTEMINJAPAN;Integrated Security=True;";

        public List<Travel> GetTravels()
        {
            var objects = new List<Travel>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command =
                    new SqlCommand(
                        "SELECT Id, Name FROM Travel",
                        connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                    objects.Add(new Travel
                    {
                        Id = Guid.Parse(reader["Id"].ToString()),
                        Name = reader["Name"].ToString(),
                    });
            }

            return objects;
        }
    }
}