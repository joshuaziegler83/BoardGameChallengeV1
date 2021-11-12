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
                    userId = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Userers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        /*
        public IEnumerable<PlayList> GetAllPlays()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Plays
                        .Select(
                            e =>
                                new PlayList
                                {
                                    PlayId = e.PlayId,
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
        public IEnumerable<PlayList> GetPlaysByBoardGameId(int BoardGameId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Plays
                        .Where(e => e.BoardGameId == BoardGameId)
                        .Select(
                            e =>
                                new PlayList
                                {
                                    PlayId = e.PlayId,
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

        public bool UpdatePlay(PlayEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                   ctx
                       .Plays
                       .Single(e => e.BoardGameId == model.BoardGameId);
                entity.PlayId = model.PlayId;
                entity.UserId = model.UserId;
                entity.BoardGameId = model.BoardGameId;
                entity.Review = model.Review;
                entity.IsReviewPrivate = model.IsReviewPrivate;
                entity.Rating = model.Rating;
                return ctx.SaveChanges() == 1;
            }

        }

        public bool DeletePlay(int BoardGameId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Plays
                        .Single(e => e.BoardGameId == BoardGameId);
                ctx.Plays.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        */
    }
}

