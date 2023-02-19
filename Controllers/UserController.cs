using cqrssAPI.Features.UserFeatures.Commands;
using cqrssAPI.Features.UserFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cqrssAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetUsersQuery()));
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            return Ok(await Mediator.Send(new GetUserByIdQuery { Id= Id }));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteUserCommand { Id= id }));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,UpdateUserCommand command)
        {
            if (id != command.Id) 
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }


    }
}
