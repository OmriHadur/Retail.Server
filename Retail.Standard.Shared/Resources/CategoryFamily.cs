using Core.Server.Shared.Resources;
using System.Collections.Generic;

namespace Retail.Standard.Shared.Resources
{
    public class CategoryFamily
    {
        public string Name { get; set; }

        public IEnumerable<CategoryResource> Categories;
    }
}
