using System;
using System.Collections.Generic;

namespace Net1711_231_ASM3_SE172092_NGUYENHOANGSON.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.

    public class Service1 : IService1
    {
        private readonly BookingRequestService bookingRequestService = new BookingRequestService();
        private readonly TravelService travelService = new TravelService();
        private readonly UserService userService = new UserService();

        public bool CreateOrUpdateBookingRequest(BookingRequest bookingRequest)
        {
            try
            {
                if (bookingRequest.Id == Guid.Empty)
                    bookingRequestService.CreateBookingRequest(bookingRequest);
                else
                    bookingRequestService.UpdateBookingRequest(bookingRequest);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteBookingRequest(Guid id)
        {
            try
            {
                bookingRequestService.DeleteBookingRequest(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<BookingRequest> GetBookingRequests()
        {
            return bookingRequestService.GetBookingRequests();
        }

        public BookingRequest GetBookingRequestById(Guid id)
        {
            return bookingRequestService.GetBookingRequestById(id);
        }

        public List<Travel> GetTravels()
        {
            return travelService.GetTravels();
        }

        public List<User> GetCustomers()
        {
            return userService.GetCustomers();
        }
    }
}