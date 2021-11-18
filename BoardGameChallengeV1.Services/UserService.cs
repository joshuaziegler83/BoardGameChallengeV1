using BoardGameChallengeV1.Data;
using BoardGameChallengeV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameChallengeV1.Services
{
    public class UserService
    {
        private readonly Guid _ownerId;

        public UserService(Guid ownerId)
        {
            _ownerId = ownerId;
        }

        public bool CreateUser(UserCreate model)
        {
            var entity =
                new ApplicationUser()
                {
                    UserId = _ownerId.ToString(),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Users.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<UserList> GetAllUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Users
                        .Select(
                            e =>
                                new UserList
                                {
                                    UserId = _ownerId.ToString(),
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                }
                                );
                return query.ToArray();
            }
        }
        public UserDetail GetUserByUserId(Guid _ownerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Users
                        .Single((e => e.UserId == _ownerId.ToString()));
                return new UserDetail
                {
                    UserId = entity.UserId,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName
                };
            }
        }

        public UserDetail GetUser(Guid userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Users
                        .Single((e => e.UserId == _ownerId.ToString()));
                return new UserDetail
                {
                    UserId = entity.UserId,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                };
            }
        }

        public bool UpdateUser(UserEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                   ctx
                       .Users
                       .Single(e => e.UserId == _ownerId.ToString());
                entity.UserId = model.UserId;
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteUser(Guid UserId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Users
                        .Single(e => e.UserId == _ownerId.ToString());
                ctx.Users.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

