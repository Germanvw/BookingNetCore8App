namespace Tarker.Booking.Application.Database.Booking.Queries.GetBookingByDocumentNumber
{
    public class GetBookingByDocumentNumberModel
    {
        public DateTime RegisterDate { get; set; }
        public required string Code { get; set; }
        public required string Type { get; set; }
    }
}
