using Commom.Dto.Storage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server.Storage.Controllers;
using Services.Storage;

namespace Server.Controllers
{
    [ApiController]
    [Route("API/Coffee")]
    public class CoffeeController : BaseController<CoffeeDto, CoffeeServices>
    {
        private readonly ILogger<CoffeeController> _logger;

        public CoffeeController(ILogger<CoffeeController> logger)
        {
            _logger = logger;
        }

    }
}
