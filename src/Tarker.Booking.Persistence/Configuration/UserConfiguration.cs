using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Persistence.Configuration
{
    public class UserConfiguration
    {
        public UserConfiguration(EntityTypeBuilder<UserEntity> entityBuilder)
        {
            entityBuilder.HasKey(x => x.UserId);
            entityBuilder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.UserName).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.Password).IsRequired().HasMaxLength(8);

            entityBuilder.HasMany(x => x.Bookings).WithOne(x => x.User).HasForeignKey(x => x.UserId);
        }
    }
}
