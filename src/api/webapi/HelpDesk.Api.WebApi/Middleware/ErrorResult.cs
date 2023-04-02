using Newtonsoft.Json;

namespace HelpDesk.Api.WebApi.Middleware
{
    public class ErrorResult : ErrorStatusCode
    {
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class ErrorStatusCode
    {
        public int StatusCode { get; set; }
    }
}
