using System.Net;

namespace ProductClientHub.Exceptions.ExceptionBase
{
    public abstract class ProductClientHubException : SystemException
    {
        protected ProductClientHubException(string errorMessage) : base(errorMessage) { }

        public abstract List<string> GetErrors();
        public abstract HttpStatusCode GetHttpStatusCode();
    }
}
