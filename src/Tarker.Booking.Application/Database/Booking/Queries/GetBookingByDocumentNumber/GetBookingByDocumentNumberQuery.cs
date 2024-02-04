using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.Database.Booking.Queries.GetBookingByDocumentNumber
{
    public class GetBookingByDocumentNumberQuery : IGetBookingByDocumentNumberQuery
    {
        private readonly IDataBaseService _dataBaseService;

        public GetBookingByDocumentNumberQuery(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<List<GetBookingByDocumentNumberModel>> Execute(string documentNumber)
        {
            var entity = await (from booking in _dataBaseService.Booking
                                join customer in _dataBaseService.Customer on booking.CustomerId equals customer.CustomerId
                                where customer.DocumentNumber == documentNumber
                                select new GetBookingByDocumentNumberModel
                                {
                                    Code = booking.Code,
                                    Type = booking.Type,
                                    RegisterDate = booking.RegisterDate,
                                }).ToListAsync();
            return entity;
        }
    }
}
