using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.Database.Customer.Queries.GetAllCustomer
{
    public class GetAllCustomerQuery: IGetAllCustomerQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetAllCustomerQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<List<GetAllCustomerQuery>> Execute()
        {
            var entityList = await _dataBaseService.Customer.ToListAsync();

            return _mapper.Map<List<GetAllCustomerQuery>>(entityList);
        }
    }
}
