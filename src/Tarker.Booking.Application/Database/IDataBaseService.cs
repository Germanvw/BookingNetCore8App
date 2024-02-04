using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.Database
{
    public interface IDataBaseService
    {
        DbSet<Domain.Entities.User.UserEntity> User { get; set; }
        DbSet<Domain.Entities.Customer.CustomerEntity> Customer { get; set; }
        DbSet<Domain.Entities.Booking.BookingEntity> Booking { get; set; }
        Task<bool> SaveAsync();
    }
}
