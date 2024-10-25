using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Net1711_231_ASM4_SE172092_NGUYENHOANGSON.Service
{
    public class UserService
    {
        private readonly string connectionString =
    "Data Source=.;Initial Catalog=FA24_SE1717_PRN231_G3_KOIORDERINGSYSTEMINJAPAN;Integrated Security=True;";

        public List<User> GetCustomers()
        {
            var objects = new List<User>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command =
                    new SqlCommand(
                        "SELECT Id, Username FROM [User]",
                        connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                    objects.Add(new User
                    {
                        Id = Guid.Parse(reader["Id"].ToString()),
                        Username = reader["Username"].ToString(),
                    });
            }

            return objects;
        }
    }
}