using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.Database.User.Commands.UpdateUserPassword
{
    public class UpdateUserPasswordCommand: IUpdateUserPasswordCommand
    {

        private readonly IDataBaseService _dataBaseService;

        public UpdateUserPasswordCommand(IDataBaseService databaseService)
        {
            _dataBaseService = databaseService;
        }

        public async Task<bool> Execute(UpdateUserPasswordModel model)
        {
          var entity = await _dataBaseService.User.FirstOrDefaultAsync(x => x.UserId == model.UserId);

            if (entity == null) return false;

            entity.Password = model.Password;

            return await _dataBaseService.SaveAsync();
        }
    }
}
