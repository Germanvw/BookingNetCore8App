using AutoMapper;
using Tarker.Booking.Domain.Entities.Customer;

namespace Tarker.Booking.Application.Database.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommand: ICreateCustomerCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreateCustomerCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<CreateCustomerModel> Execute(CreateCustomerModel model)
        {
            CustomerEntity entity = _mapper.Map<CustomerEntity>(model);

            await _dataBaseService.Customer.AddAsync(entity);
            await _dataBaseService.SaveAsync();

            return _mapper.Map<CreateCustomerModel>(entity);
        }
    }
}
