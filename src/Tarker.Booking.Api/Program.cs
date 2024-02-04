using Tarker.Booking.Api;
using Tarker.Booking.Application;
using Tarker.Booking.Common;
using Tarker.Booking.Persistence;
using Tarker.Booking.External;
using Tarker.Booking.Application.Database.User.Queries.GetUserByUserNameAndPassword;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWebApi().AddCommon().AddApplication().AddExternal(builder.Configuration).AddPersistance(builder.Configuration);

var app = builder.Build();

app.MapPost("/Test", async (IGetUserByUserNameAndPasswordQuery service) =>
{
    return await service.Execute("User1", "12345");
});
    
app.Run();
