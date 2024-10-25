using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Net1711_231_ASM3_SE172092_NGUYENHOANGSON.Service
{
    public class BookingRequestService
    {
        private readonly string connectionString =
            "Data Source=.;Initial Catalog=FA24_SE1717_PRN231_G3_KOIORDERINGSYSTEMINJAPAN;Integrated Security=True;";

        public List<BookingRequest> GetBookingRequests()
        {
            var bookingRequests = new List<BookingRequest>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command =
                    new SqlCommand(
                        "SELECT Id, CustomerId, TravelId, QuantityService, NumberOfPerson, Status, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate, IsDeleted, Note FROM BookingRequest",
                        connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    BookingStatus statusValue;
                    var statusString = reader["Status"].ToString();
                    if (!Enum.TryParse(statusString, out statusValue))
                    {
                        statusValue = BookingStatus.Pending;
                    }

                    bookingRequests.Add(new BookingRequest
                    {
                        Id = Guid.Parse(reader["Id"].ToString()),
                        CustomerId = reader["CustomerId"] != DBNull.Value
                            ? Guid.Parse(reader["CustomerId"].ToString())
                            : (Guid?)null,
                        TravelId = reader["TravelId"] != DBNull.Value
                            ? Guid.Parse(reader["TravelId"].ToString())
                            : (Guid?)null,
                        QuantityService = int.Parse(reader["QuantityService"].ToString()),
                        NumberOfPerson = int.Parse(reader["NumberOfPerson"].ToString()),
                        Status = statusValue,
                        CreatedBy = reader["CreatedBy"].ToString(),
                        CreatedDate = (DateTime)reader["CreatedDate"],
                        UpdatedBy = reader["UpdatedBy"].ToString(),
                        UpdatedDate = (DateTime)reader["UpdatedDate"],
                        IsDeleted = (bool)reader["IsDeleted"],
                        Note = reader["Note"].ToString()
                    });
                }
            }

            return bookingRequests;
        }

        public BookingRequest GetBookingRequestById(Guid id)
        {
            BookingRequest bookingRequest = null;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command =
                    new SqlCommand(
                        "SELECT Id, CustomerId, TravelId, QuantityService, NumberOfPerson, Status, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate, IsDeleted, Note FROM BookingRequest WHERE Id = @Id",
                        connection);
                command.Parameters.AddWithValue("@Id", id);
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    BookingStatus statusValue;
                    var statusString = reader["Status"].ToString();
                    if (!Enum.TryParse(statusString, out statusValue))
                    {
                        statusValue = BookingStatus.Pending;
                    }
                    bookingRequest = new BookingRequest
                    {
                        Id = Guid.Parse(reader["Id"].ToString()),
                        CustomerId = reader["CustomerId"] != DBNull.Value
                            ? Guid.Parse(reader["CustomerId"].ToString())
                            : (Guid?)null,
                        TravelId = reader["TravelId"] != DBNull.Value
                            ? Guid.Parse(reader["TravelId"].ToString())
                            : (Guid?)null,
                        QuantityService = int.Parse(reader["QuantityService"].ToString()),
                        NumberOfPerson = int.Parse(reader["NumberOfPerson"].ToString()),
                        Status = statusValue,
                        CreatedBy = reader["CreatedBy"].ToString(),
                        CreatedDate = (DateTime)reader["CreatedDate"],
                        UpdatedBy = reader["UpdatedBy"].ToString(),
                        UpdatedDate = (DateTime)reader["UpdatedDate"],
                        IsDeleted = (bool)reader["IsDeleted"],
                        Note = reader["Note"].ToString()
                    };
                }
            }

            return bookingRequest;
        }

        public void CreateBookingRequest(BookingRequest bookingRequest)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "INSERT INTO BookingRequest (Id, CustomerId, TravelId, QuantityService, NumberOfPerson, Status, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate, IsDeleted, Note) " +
                    "VALUES (@Id, @CustomerId, @TravelId, @QuantityService, @NumberOfPerson, @Status, @CreatedBy, @CreatedDate, @UpdatedBy, @UpdatedDate, @IsDeleted, @Note)",
                    connection);
                var newId = Guid.NewGuid(); 
                command.Parameters.AddWithValue("@Id", newId);
                command.Parameters.AddWithValue("@CustomerId",
                    bookingRequest.CustomerId.HasValue ? (object)bookingRequest.CustomerId.Value : DBNull.Value);
                command.Parameters.AddWithValue("@TravelId",
                    bookingRequest.TravelId.HasValue ? (object)bookingRequest.TravelId.Value : DBNull.Value);
                command.Parameters.AddWithValue("@QuantityService", bookingRequest.QuantityService);
                command.Parameters.AddWithValue("@NumberOfPerson", bookingRequest.NumberOfPerson);
                command.Parameters.AddWithValue("@Status", bookingRequest.Status.ToString());
                command.Parameters.AddWithValue("@CreatedBy", bookingRequest.CreatedBy);
                command.Parameters.AddWithValue("@CreatedDate", bookingRequest.CreatedDate);
                command.Parameters.AddWithValue("@UpdatedBy", bookingRequest.UpdatedBy);
                command.Parameters.AddWithValue("@UpdatedDate", bookingRequest.UpdatedDate);
                command.Parameters.AddWithValue("@IsDeleted", bookingRequest.IsDeleted);
                command.Parameters.AddWithValue("@Note", bookingRequest.Note);

                command.ExecuteNonQuery();
            }
        }

        public void UpdateBookingRequest(BookingRequest bookingRequest)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "UPDATE BookingRequest SET CustomerId = @CustomerId, TravelId = @TravelId, QuantityService = @QuantityService, NumberOfPerson = @NumberOfPerson, " +
                    "Status = @Status, CreatedBy = @CreatedBy, CreatedDate = @CreatedDate, UpdatedBy = @UpdatedBy, UpdatedDate = @UpdatedDate, " +
                    "IsDeleted = @IsDeleted, Note = @Note WHERE Id = @Id", connection);

                command.Parameters.AddWithValue("@Id", bookingRequest.Id);
                command.Parameters.AddWithValue("@CustomerId",
                    bookingRequest.CustomerId.HasValue ? (object)bookingRequest.CustomerId.Value : DBNull.Value);
                command.Parameters.AddWithValue("@TravelId",
                    bookingRequest.TravelId.HasValue ? (object)bookingRequest.TravelId.Value : DBNull.Value);
                command.Parameters.AddWithValue("@QuantityService", bookingRequest.QuantityService);
                command.Parameters.AddWithValue("@NumberOfPerson", bookingRequest.NumberOfPerson);
                command.Parameters.AddWithValue("@Status", bookingRequest.Status.ToString());
                command.Parameters.AddWithValue("@CreatedBy", bookingRequest.CreatedBy);
                command.Parameters.AddWithValue("@CreatedDate", bookingRequest.CreatedDate);
                command.Parameters.AddWithValue("@UpdatedBy", bookingRequest.UpdatedBy);
                command.Parameters.AddWithValue("@UpdatedDate", bookingRequest.UpdatedDate);
                command.Parameters.AddWithValue("@IsDeleted", bookingRequest.IsDeleted);
                command.Parameters.AddWithValue("@Note", bookingRequest.Note);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteBookingRequest(Guid id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM BookingRequest WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}