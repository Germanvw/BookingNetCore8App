namespace Tarker.Booking.Application.Database.Customer.Commands.UpdateCustomer
{
    public class UpdateCustomerModel
    {
        public int CustomerId { get; set; }
        public required string FullName { get; set; }
        public required string DocumentNumber { get; set; }
    }
}
