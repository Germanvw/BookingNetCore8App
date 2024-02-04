namespace Tarker.Booking.Application.Database.User.Queries.GetUserById
{
    public class GetUserByIdModel
    {
        public int UserId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}
