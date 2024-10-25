using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Net1711_231_ASM4_SE172092_NGUYENHOANGSON.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<BookingRequest> GetBookingRequests();
        
        [OperationContract]
        List<Travel> GetTravels();
        [OperationContract]
        List<User> GetCustomers();

        [OperationContract]
        bool CreateOrUpdateBookingRequest(BookingRequest bookingRequest);

        [OperationContract]
        bool DeleteBookingRequest(Guid id);

        [OperationContract]
        BookingRequest GetBookingRequestById(Guid id);
    }
}