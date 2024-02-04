namespace Tarker.Booking.Application.Database.Customer.Commands.CreateCustomer
{
    public class CreateCustomerModel
    {
        public required string FullName { get; set; }
        public required string DocumentNumber { get; set; }
    }
}
