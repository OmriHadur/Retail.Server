﻿using Core.Server.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Retail.Shared.Resources;

namespace Retail.Web.Controllers
{
    [Route("api/departments/{parentId}/categories")]
    [ApiController]
    public class CategoriesController : InnerRestController<CategoryCreateResource, CategoryResource>
    {
    }
}
