namespace Tarker.Booking.Application.Database.User.Queries.GetUserByUserNameAndPassword
{
    public class GetUserByUserNameAndPasswordModel
    {
        public int UserId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}
