using Tarker.Booking.Api;
using Tarker.Booking.Application;
using Tarker.Booking.Common;
using Tarker.Booking.Persistence;
using Tarker.Booking.External;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWebApi().AddCommon().AddApplication().AddExternal(builder.Configuration).AddPersistance(builder.Configuration);

var app = builder.Build();

app.Run();
