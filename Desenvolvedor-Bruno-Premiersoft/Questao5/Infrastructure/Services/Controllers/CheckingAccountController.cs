using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Queries.Requests;
using Questao5.Infrastructure.CrossCutting;
using System.Net;

namespace Questao5.Infrastructure.Services.Controllers
{
    [Route("checking-account")]

    public class CheckingAccountController : HomeController
    {
        IMediator _mediator;

        public CheckingAccountController(ILogger<HomeController> logger,
                                         List<Notifications> notifications, IMediator mediator) : base(logger, notifications)
        {
            _mediator = mediator;
        }



        // <summary>
        /// Movement the account with credit or debit
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Returns the item</response>
        /// <response code="500">Internal server error</response>   
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpPost]
        [Route("movement")]
        public async Task<IActionResult> CheckingAccountMovement([FromBody] CheckingAccountMovementCommand command)
        {
            return await ExecControllerAsync(() => _mediator.Send(command));
        }

        [Route("balance")]
        public async Task<IActionResult> CheckingAccountBalance([FromQuery] GetBalanceQuery request)
        {
            return await ExecControllerAsync(() => _mediator.Send(request));
        }
    }
}
