﻿namespace Tarker.Booking.Application.Database.Booking.Queries.GetAllBooking
{
    public class GetAllBookingModel
    {
        public int BookingId { get; set; }
        public DateTime RegisterDate { get; set; }
        public required string Code { get; set; }
        public required string Type { get; set; }
        public required string CustomerFullName { get; set; }
        public required string CustomerDocumentNumber { get; set; }
    }
}
