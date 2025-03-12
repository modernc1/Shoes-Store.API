using E_Commerce.Application.Mediator.Authentications.CreateUser;
using E_Commerce.Application.Mediator.Authentications.LoginUser;
using E_Commerce.Application.Mediator.Authentications.ReviveToken;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IMediator mediator) : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            var response = await mediator.Send(command);
            
            return response.Success? Ok(response) : BadRequest(response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser(LoginUserCommand command)
        {
            var response = await mediator.Send(command);

            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> ReviveToken([FromBody]ReviveTokenCommand command)
        {
            var response = await mediator.Send(command);

            return response.Success ? Ok(response) : BadRequest(response);
        } 
    }
}
