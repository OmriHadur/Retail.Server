using System;
using System.Collections.Generic;
using System.Text;

namespace Retail.Standard.Client.Results
{
    public class OkResultWithObject<T> : ActionResult<T>
    {
        public OkResultWithObject(ActionResult result)
            : base(result)
        {

        }
        public OkResultWithObject(T value)
            : base(value)
        {

        }
    }
}