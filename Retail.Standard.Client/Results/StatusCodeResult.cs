using Retail.Standard.Client.Results;

namespace Retail.Standard.Client.Results
{
    public class StatusCodeResult : ActionResult
    {
        public int StatusCode { get; protected set; }

        public StatusCodeResult(int statusCode)
        {
            this.StatusCode = statusCode;
        }
    }
}