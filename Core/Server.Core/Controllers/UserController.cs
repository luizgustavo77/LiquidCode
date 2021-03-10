using Commom.Dto.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server.Storage.Controllers;
using Services.Core;
using System.Threading.Tasks;

namespace Server.Core.Controllers
{
    [ApiController]
    [Route("API/User")]
    public class UserController : BaseController<UserDto, UserServices>
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [Route("Login/{login}/{password}")]
        [HttpGet]
        public async Task<UserDto> Login([FromRoute] string login, [FromRoute] string password)
        {
            return new UserServices().Login(login, password);
        }

    }
}
