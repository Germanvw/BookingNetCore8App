namespace Tarker.Booking.Application.Database.Booking.Queries.GetBookingByDocumentNumber
{
    public interface IGetBookingByDocumentNumberQuery
    {
        Task<List<GetBookingByDocumentNumberModel>> Execute(string documentNumber);
    }
}
