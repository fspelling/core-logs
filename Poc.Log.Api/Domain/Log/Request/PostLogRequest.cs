using NLog;

namespace Poc.Log.Api.Domain.Log.Request
{
    public class LogPostRequest
    {
        public string System { get; set; }
        public LogEventInfo ObjectSystem { get; set; }
    }
}
