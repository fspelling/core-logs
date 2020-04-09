using Microsoft.AspNetCore.Mvc;
using NLog.Web;
using Poc.Log.Api.Domain.Log.Request;
using Poc.Log.Api.Domain.Log.Response;
using System;

namespace Poc.Log.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : Controller
    {
        [HttpPost]
        public IActionResult Post([FromBody]LogPostRequest objLog)
        {
            try
            {
                if (string.IsNullOrEmpty(objLog.System) || objLog.ObjectSystem == null)
                    return BadRequest(new LogPostResponse(400, "Bad Request", "Parametro(s) da requisicao invalido(s)."));

                NLogBuilder.ConfigureNLog($"nlog/{objLog.System}.config")
                                        .GetCurrentClassLogger()
                                        .Log(objLog.ObjectSystem);

                return Ok(new LogPostResponse(200, "OK", "Log gravado com sucesso"));
            }
            catch (Exception e)
            {
                return StatusCode(500, new LogPostResponse(500, "Server Error", $"Erro ao gravar o log: ${e.Message}"));
            }
        }
    }
}
