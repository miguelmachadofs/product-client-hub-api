using System.Net;

namespace ProductClientHub.Exceptions.ExceptionBase
{
    public class NotFoundException(string errorMessage) : ProductClientHubException(errorMessage)
    {
        public override List<string> GetErrors() => [Message];

        public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.NotFound;
    }
}
