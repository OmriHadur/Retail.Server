﻿using Microsoft.AspNetCore.Mvc;

namespace Retail.Common.Errors
{
    public class NotFoundApplicationResult : NotFoundObjectResult
    {
        public string Id { get; private set; }   
        public NotFoundApplicationResult(string id)
            :base($"Object with id {id} was not found")
        {
            Id = id;
        }
    }
}
