using BoardGameChallengeV1.Models;
using System;
using System.Collections.Generic;

namespace BoardGameChallengeV1.Services
{
    public interface IUserService
    {
        bool CreateUser(UserCreate model);
        bool DeleteUser(Guid UserId);
        IEnumerable<UserList> GetAllUsers();
        UserDetail GetUser(Guid userId);
        UserDetail GetUserByUserId(Guid _ownerId);
        bool UpdateUser(UserEdit model);
    }
}