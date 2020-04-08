using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog.Mongo;
using NLog.Web;
using System.Collections.Generic;

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
        }

        [HttpGet]
        public void Get()
        {
            //var mongoTarget = new MongoTarget()
            //{ 
            //    Name = "mongo3",
            //    DatabaseName = "TestLog",
            //    CollectionName = "Logs",
            //    ConnectionString = "mongodb://localhost:27017"
            //};

            //var config = new NLog.Config.LoggingConfiguration();
            //config.AddRule(NLog.LogLevel.Info, NLog.LogLevel.Fatal, mongoTarget);
            //NLog.LogManager.Configuration = config;

            NLogBuilder.ConfigureNLog("nlog/quitaqui.config").GetCurrentClassLogger();
            _logger.LogInformation("test log");
        }
    }
}