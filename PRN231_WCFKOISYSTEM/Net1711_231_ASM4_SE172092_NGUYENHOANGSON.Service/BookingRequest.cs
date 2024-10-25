using System;

namespace Net1711_231_ASM4_SE172092_NGUYENHOANGSON.Service
{
    public class BookingRequest
    {
        public Guid Id { get; set; }

        public Guid? CustomerId { get; set; }

        public Guid? TravelId { get; set; }

        public int QuantityService { get; set; }

        public int NumberOfPerson { get; set; }

        public BookingStatus Status { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public bool IsDeleted { get; set; }

        public string Note { get; set; }
    }

    public enum BookingStatus
    {
        Pending,
        Approved,
        Rejected
    }
}