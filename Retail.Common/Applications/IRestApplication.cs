using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Retail.Standard.Shared.Resources;
using Retail.Standard.Shared.Resources.Users;

namespace Retail.Common.Applications
{
    public interface IRestApplication<TCreateResource, TResource>
        where TCreateResource : CreateResource
        where TResource : Resource
    {
        UserResource CurrentUser { get; set; }

        Task<ActionResult<IEnumerable<TResource>>> Get();

        Task<ActionResult<TResource>> Get(string id);

        Task<ActionResult<TResource>> Create(TCreateResource resource);

        Task<ActionResult<TResource>> Update(string id, TCreateResource resource);

        Task<ActionResult> Delete(string id);

        Task<ActionResult> Exists(string id);
    }
}