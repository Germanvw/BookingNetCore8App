using Microsoft.AspNetCore.Mvc;
using Tarker.Booking.Application.Database.Customer.Commands.CreateCustomer;
using Tarker.Booking.Application.Database.Customer.Commands.DeleteCustomer;
using Tarker.Booking.Application.Database.Customer.Commands.UpdateCustomer;
using Tarker.Booking.Application.Database.Customer.Queries.GetAllCustomer;
using Tarker.Booking.Application.Database.Customer.Queries.GetCustomerByDocumentNumber;
using Tarker.Booking.Application.Database.Customer.Queries.GetCustomerById;
using Tarker.Booking.Application.Exceptions;
using Tarker.Booking.Application.Features;

namespace Tarker.Booking.Api.Controllers
{
    [Route("api/v1/Customer")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class BookingController : ControllerBase
    {

        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] CreateCustomerModel model, [FromServices] ICreateCustomerCommand command)
        {
            var response = await command.Execute(model);

            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, response));
        }

        [HttpPut()]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerModel model, [FromServices] IUpdateCustomerCommand command)
        {
            var response = await command.Execute(model);

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, response));
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> Delete(int customerId, [FromServices] IDeleteCustomerCommand command)
        {
            if (customerId == 0) return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

            var response = await command.Execute(customerId);

            if (!response) return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, response));
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllUsers([FromServices] IGetAllCustomerQuery command)
        {
            var response = await command.Execute();

            if (response.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, response));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, response));
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetAllUsers(int customerId, [FromServices] IGetCustomerByIdQuery command)
        {
            if (customerId == 0) return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

            var response = await command.Execute(customerId);

            if (response == null) return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, response));
        }

        [HttpGet("DocumentNumber/{documentNumber}")]
        public async Task<IActionResult> GetAllUsers(string documentNumber, [FromServices] IGetCustomerByDocumentNumberQuery command)
        {
            if (string.IsNullOrEmpty(documentNumber)) return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

            var response = await command.Execute(documentNumber);

            if (response == null) return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, response));
        }
    }
}
