using Application.Feautres.Users.Commands.CreateUserCommand;
using Application.Feautres.Users.Queries.GetUserByUsernameAndPassword;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateUserCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("{command}")]
        public async Task<IActionResult> GetUserByUsernameAndPassword(GetUserByUsernameAndPasswordCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
