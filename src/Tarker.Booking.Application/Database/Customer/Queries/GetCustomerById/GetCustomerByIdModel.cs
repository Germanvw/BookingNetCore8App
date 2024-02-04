namespace Tarker.Booking.Application.Database.Customer.Queries.GetCustomerById
{
    public class GetCustomerByIdModel
    {
        public int CustomerId { get; set; }
        public required string FullName { get; set; }
        public required string DocumentNumber { get; set; }
    }
}
