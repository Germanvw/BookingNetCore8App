using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.Database.User.Commands.DeleteUser
{
    public class DeleteUserCommand : IDeleteUserCommand
    {
        private readonly IDataBaseService _dataBaseService;

        public DeleteUserCommand(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<bool> Execute(int entityId)
        {
            var entity = await _dataBaseService.User.FirstOrDefaultAsync(x => x.UserId == entityId);

            if (entity == null) return false;

            _dataBaseService.User.Remove(entity);

            return await _dataBaseService.SaveAsync();
        }
    }
}
