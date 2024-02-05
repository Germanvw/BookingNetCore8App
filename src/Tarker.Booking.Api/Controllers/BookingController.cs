using Microsoft.AspNetCore.Mvc;
using Tarker.Booking.Application.Database.Booking.Commands.CreateBooking;
using Tarker.Booking.Application.Database.Booking.Queries.GetAllBooking;
using Tarker.Booking.Application.Database.Booking.Queries.GetBookingByDocumentNumber;
using Tarker.Booking.Application.Database.Booking.Queries.GetBookingByType;
using Tarker.Booking.Application.Exceptions;
using Tarker.Booking.Application.Features;

namespace Tarker.Booking.Api.Controllers
{
    [Route("api/v1/Booking")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class CustomerController : ControllerBase
    {
        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] CreateBookingModel model, [FromServices] ICreateBookingCommand command)
        {
            var response = await command.Execute(model);

            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, response));
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll([FromServices] IGetAllBookingQuery command)
        {
            var response = await command.Execute();

            if (response.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, response));

            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, response));
        }

        [HttpGet("byDocumentNumber")]
        public async Task<IActionResult> GetByDocumentNumber([FromQuery] string documentNumber, [FromServices] IGetBookingByDocumentNumberQuery command)
        {
            if (string.IsNullOrEmpty(documentNumber))
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

            var response = await command.Execute(documentNumber);

            if (response.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, response));

            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, response));
        }

        [HttpGet(template: "byType")]
        public async Task<IActionResult> GetByType([FromQuery] string type, [FromServices] IGetBookingByTypeQuery command)
        {
            if (string.IsNullOrEmpty(type))
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

            var response = await command.Execute(type);

            if (response.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, response));

            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, response));
        }
    }
}
