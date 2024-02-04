namespace Tarker.Booking.Application.Database.Customer.Queries.GetCustomerByDocumentNumber
{
    public class GetCustomerByDocumentNumberModel
    {
        public int CustomerId { get; set; }
        public required string FullName { get; set; }
        public required string DocumentNumber { get; set; }
    }
}
