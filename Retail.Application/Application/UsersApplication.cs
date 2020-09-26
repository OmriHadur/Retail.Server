﻿using Retail.Application.Helper;
using Retail.Common.Applications;
using Retail.Common.Entities;
using Retail.Common.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Retail.Common;
using Retail.Standard.Shared.Resources.Users;
using Retail.Standard.Shared.Errors;
using Unity;
using System.Collections.Generic;

namespace Retail.Application.Application
{
    [Inject]
    public class UsersApplication : RestApplication<UserCreateResource, UserResource, UserEntity>, IUsersApplication
    {
        private IUsersRepository _usersRepository => Repository as IUsersRepository;
        private PasswordHasher _passwordHasher = new PasswordHasher();

        [Dependency]
        public ILoginsApplication LoginsApplication;

        protected override UserEntity GetNewTEntity(UserCreateResource resource)
        {
            var userEntity = base.GetNewTEntity(resource);
            byte[] passwordHash, passwordSalt;
            _passwordHasher.CreatePasswordHash(resource.Password, out passwordHash, out passwordSalt);
            userEntity.PasswordHash = passwordHash;
            userEntity.PasswordSalt = passwordSalt;
            return userEntity;
        }

        public async override Task<ActionResult<UserResource>> Create(UserCreateResource createResource)
        {
            if (await _usersRepository.EmailExists(createResource.Email))
                return BadRequest(BadRequestReason.SameExists);

            return await base.Create(createResource);
        }

        public async override Task<ActionResult> Delete(string id)
        {
            var respose = await base.Delete(id);
            if (respose is OkResult)
                await LoginsApplication.DeleteByUserId(id);
            return respose;
        }
    }
}