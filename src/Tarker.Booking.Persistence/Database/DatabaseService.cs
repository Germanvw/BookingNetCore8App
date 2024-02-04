using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.Database;
using Tarker.Booking.Persistence.Configuration;

namespace Tarker.Booking.Persistence.Database
{
    public class DatabaseService : DbContext, IDataBaseService
    {
        public DatabaseService(DbContextOptions<DatabaseService> options) : base(options)
        {
        
        }

        public DbSet<Domain.Entities.User.UserEntity> User { get; set; }
        public DbSet<Domain.Entities.Customer.CustomerEntity> Customer { get; set; }
        public DbSet<Domain.Entities.Booking.BookingEntity> Booking { get; set; }

        public async Task<bool> SaveAsync()
        {
            return await SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfiguration(modelBuilder);
        }

        private void EntityConfiguration(ModelBuilder modelBuilder)
        {
            new UserConfiguration(modelBuilder.Entity<Domain.Entities.User.UserEntity>());
            new CustomerConfiguration(modelBuilder.Entity<Domain.Entities.Customer.CustomerEntity>());
            new BookingConfiguration(modelBuilder.Entity<Domain.Entities.Booking.BookingEntity>());
        }
    }
}
