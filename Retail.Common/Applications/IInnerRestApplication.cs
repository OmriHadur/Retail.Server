﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Retail.Standard.Shared.Resources;
using Retail.Standard.Shared.Resources.Users;

namespace Retail.Common.Applications
{
    public interface IInnerRestApplication<TCreateResource,TResource>
        where TCreateResource : CreateResource
        where TResource : Resource
    {
        UserResource CurrentUser { get; set; }

        Task<ActionResult<IEnumerable<TResource>>> Get(string parentId);

        Task<ActionResult<TResource>> Get(string parentId, string id);

        Task<ActionResult<TResource>> Create(string parentId, TCreateResource resource);

        Task<ActionResult<TResource>> Update(string parentId, string id, TCreateResource resource);

        Task<ActionResult<TResource>> Delete(string parentId, string id);
    }
}