using Retail.Standard.Shared.Errors;

namespace Retail.Standard.Client.Results
{
    public class BadRequestResult : ActionResult
    {
        public BadRequestReason Reason { get; private set; }
        public BadRequestResult(BadRequestReason reason)
        {
            Reason = reason;
        }
    }
}
