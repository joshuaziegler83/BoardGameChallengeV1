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
        private readonly Guid _userId;

        public UserService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateUser(UserCreate model)
        {
            var entity =
                new User()
                {
                    UserId = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Userers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<UserList> GetAllUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Userers
                        .Select(
                            e =>
                                new UserList
                                {
                                    UserId = e.UserId,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                }
                                );
                return query.ToArray();
            }
        }
        public UserDetail GetUserByUserId(Guid userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Userers
                        .Single((e => e.UserId == userId));
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
                        .Userers
                        .Single((e => e.UserId == userId));
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
                       .Userers
                       .Single(e => e.UserId == model.UserId);
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
                        .Userers
                        .Single(e => e.UserId == UserId);
                ctx.Userers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

