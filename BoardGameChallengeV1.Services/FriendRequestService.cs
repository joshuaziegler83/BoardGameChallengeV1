using BoardGameChallengeV1.Data;
using BoardGameChallengeV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameChallengeV1.Services
{
    public class FriendRequestService
    {
        private readonly Guid _userId;

        public FriendRequestService(Guid userId)
        {
            _userId = userId;
        }

       public bool CreateFriendRequest(FriendRequestCreate model)
        {
            var entity =
                new FriendRequest()
                {
                    FriendRequestId = model.FriendRequestId,
                    UserId1 = model.UserId1,
                    UserId2 = model.UserId2,
                    IsAccepted = model.IsAccepted
                };
           entity.Messages.Add(model.Message);
            using (var ctx = new ApplicationDbContext())
            {
                ctx.FriendRequests.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<FriendRequestList> GetAllFriendRequests()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .FriendRequests
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
        
        /*public IEnumerable<FriendRequestList> GetFriendRequestsByUserId(_userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .FriendRequests
                        .Where(e => e.BoardGameId == BoardGameId)
                        .Select(
                            e =>
                                new FriendRequestList
                                {
                                    FriendRequestId = e.FriendRequestId,
                                    UserId = e.UserId,
                                    BoardGameId = e.BoardGameId,
                                    Review = e.Review,
                                    IsReviewPrivate = e.IsReviewPrivate,
                                    Rating = e.Rating
                                }
                                );
                return query.ToArray();
            }
        }
*/
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

