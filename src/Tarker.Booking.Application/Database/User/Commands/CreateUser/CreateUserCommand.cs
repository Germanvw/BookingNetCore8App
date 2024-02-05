using AutoMapper;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Application.Database.User.Commands.CreateUser
{
    public class CreateUserCommand: ICreateUserCommand
    {
        private readonly IDataBaseService _databaseService;
        private readonly IMapper _mapper;

        public CreateUserCommand(IDataBaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }

        public async Task<CreateUserModel> Execute(CreateUserModel model)
        {
            UserEntity entity = _mapper.Map<UserEntity>(model);

            await _databaseService.User.AddAsync(entity);
            await _databaseService.SaveAsync();

            return _mapper.Map<CreateUserModel>(entity);
        }
    }
}
