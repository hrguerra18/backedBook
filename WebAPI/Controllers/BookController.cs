using Application.Feautres.Books.Commands.CreateBookCommand;
using Application.Feautres.Books.Commands.DeleteBookCommand;
using Application.Feautres.Books.Commands.UpdateBookCommand;
using Application.Feautres.Books.Queries.GetAllBook;
using Application.Feautres.Books.Queries.GetBookById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetAllBookQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _mediator.Send(new GetBookByIdQuery { Id = id}));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateBookCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,UpdateBookCommand command)
        {
            if (id != command.Id)
                return BadRequest();
            
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteBookCommand { Id = id}));
        }
    }
}
