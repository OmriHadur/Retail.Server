﻿using Retail.Common.Entities;
using System.Threading.Tasks;

namespace Retail.Common.Repositories
{
    public interface ILoginsRepository : IRepository<LoginEntity>
    {
        Task<LoginEntity> GetByUserId(string id);
        Task DeleteByUserId(string id);
    }
}
