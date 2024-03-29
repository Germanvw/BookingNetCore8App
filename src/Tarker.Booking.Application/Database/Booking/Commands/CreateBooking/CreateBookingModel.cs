﻿namespace Tarker.Booking.Application.Database.Booking.Commands.CreateBooking
{
    public class CreateBookingModel
    {
        public int BookingId { get; set; }
        public required string Code { get; set; }
        public required string Type { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
    }
}
