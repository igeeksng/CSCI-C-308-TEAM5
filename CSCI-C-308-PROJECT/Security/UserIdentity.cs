﻿
namespace CSCI_308_TEAM5.API.Security
{
    public sealed record UserIdentity : IUserIdentity
    {
        public Guid userId { get; set; }

        public string username { get; set; }

        public Roles accessRole { get; set; }
    }
}