namespace Poc.Log.Api.Domain.Base
{
    public abstract class ResponseBase
    {
        public int StatusCode { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }

        public ResponseBase(int statusCode, string title, string message)
        {
            StatusCode = statusCode;
            Title = title;
            Message = message;
        }
    }
}
