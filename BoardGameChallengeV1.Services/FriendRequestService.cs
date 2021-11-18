using BoardGameChallengeV1.Data;
using BoardGameChallengeV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameChallengeV1.Services
{
    public class FriendRequestService : IFriendRequestService
    {
        private readonly Guid _ownerId;

        public FriendRequestService(Guid ownerId)
        {
            _ownerId = ownerId;
        }

        public bool CreateFriendRequest(FriendRequestCreate model)
        {
            var entity =
                new FriendRequest()
                {
                    FriendRequestId = model.FriendRequestId,
                    UserId1 = _ownerId.ToString(),
                    UserId2 = model.UserId2,
                    IsAccepted = model.IsAccepted
                };
            // entity.Messages.Add(model.Message);
            using (var ctx = new ApplicationDbContext())
            {
                ctx.FriendRequests.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<FriendRequestList> GetFriendRequestsByUserId(Guid userId1)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .FriendRequests
                        .Where(e => e.UserId1 == _ownerId.ToString())
                        .Select(
                            e =>
                                new FriendRequestList
                                {
                                    FriendRequestId = e.FriendRequestId,
                                    UserId1 = e.UserId1,
                                    UserId2 = e.UserId2,
                                    IsAccepted = e.IsAccepted,
                                }
                                );
                return query.ToArray();
            }
        }

        public FriendRequestDetail GetFriendRequestByFriendRequestId(int friendRequestId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .FriendRequests
                        .Single((e => e.FriendRequestId == friendRequestId));
                return new FriendRequestDetail
                {
                    FriendRequestId = entity.FriendRequestId,
                    UserId1 = entity.UserId1,
                    UserId2 = entity.UserId2,
                    IsAccepted = entity.IsAccepted
                };
            }
        }

        public bool UpdateFriendRequest(FriendRequestEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                   ctx
                       .FriendRequests
                       .Single(e => e.FriendRequestId == model.FriendRequestId);
                entity.FriendRequestId = model.FriendRequestId;
                entity.UserId1 = model.UserId1;
                entity.UserId2 = model.UserId2;
                entity.IsAccepted = model.IsAccepted;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteFriendRequest(int FriendRequestId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .FriendRequests
                        .Single(e => e.FriendRequestId == FriendRequestId);
                ctx.FriendRequests.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

