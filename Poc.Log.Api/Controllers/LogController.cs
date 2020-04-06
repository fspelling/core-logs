using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Poc.Log.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : Controller
    {
        private readonly ILogger<LogController> _logger;

        public LogController(ILogger<LogController> logger)
        {
            _logger = logger;
            _logger.LogDebug("NLog injetado no LogController");
            _logger.Log()
        }

        public void Post()
        {
            _logger.LogInformation("test log");
        }
    }
}