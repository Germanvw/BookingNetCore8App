﻿namespace Tarker.Booking.Application.Database.Customer.Queries.GetAllCustomer
{
    public class GetAllCustomerModel
    {
        public int CustomerId { get; set; }
        public required string FullName { get; set; }
        public required string DocumentNumber { get; set; }
    }
}
