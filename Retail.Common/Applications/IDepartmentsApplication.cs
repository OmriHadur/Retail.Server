﻿using Core.Server.Common.Applications;
using Retail.Standard.Shared.Resources;

namespace Retail.Common.Applications
{
    public interface IDepartmentsApplication : IRestApplication<DepartmentCreateResource, DepartmentResource>
    {
    }
}
