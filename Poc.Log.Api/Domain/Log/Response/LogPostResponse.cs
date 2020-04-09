using Poc.Log.Api.Domain.Base;

namespace Poc.Log.Api.Domain.Log.Response
{
    public class LogPostResponse : ResponseBase
    {
        public LogPostResponse(int statusCode, string title, string message) : base(statusCode, title, message)
        {
        }
    }
}
