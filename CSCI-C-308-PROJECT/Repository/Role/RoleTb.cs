﻿using CSCI_308_TEAM5.API.Security;
using CSCI_308_TEAM5.API.Services.Config;

namespace CSCI_308_TEAM5.API.Repository.Role
{
    interface IRoleTb
    {
        Task<bool> any(Guid userId, Roles role);

        Task add(Guid userId, Roles role);
    }

    sealed class RoleTb(IConfigService configService) : IRoleTb
    {
        public Task add(Guid userId, Roles role)
        {
            throw new NotImplementedException();
        }

        public Task<bool> any(Guid userId, Roles role)
        {
            throw new NotImplementedException();
        }
    }
}
