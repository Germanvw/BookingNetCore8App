﻿namespace Tarker.Booking.Application.Database.Customer.Queries.GetAllCustomer
{
    public interface IGetAllCustomerQuery
    {
        Task<List<GetAllCustomerQuery>> Execute();
    }
}