using Microsoft.AspNetCore.Mvc;
using Retail.Standard.Shared.Errors;

namespace Retail.Common.Errors
{
    public class BadRequestApplicationResult : BadRequestObjectResult
    {
        public BadRequestApplicationResult(BadRequestReason reason) 
            : base(reason)
        {

        }
    }
}
