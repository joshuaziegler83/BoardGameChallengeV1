using BoardGameChallengeV1.Data;
using BoardGameChallengeV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameChallengeV1.Services
{
    public class PlayService : IPlayService
    {
        private readonly Guid _ownerId;

        public PlayService(Guid ownerId)
        {
            _ownerId = ownerId;
        }

        public bool CreatePlay(PlayCreate model)
        {
            var entity =
                new Play()
                {
                    UserId = _ownerId.ToString(),
                    BoardGameId = model.BoardGameId,
                    Review = model.Review,
                    IsReviewPrivate = model.IsReviewPrivate,
                    Rating = model.Rating
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Plays.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public PlayDetail GetPlay(int playId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Plays
                        .Single((e => e.PlayId == playId));
                return new PlayDetail
                {
                    PlayId = entity.PlayId,
                    UserId = entity.UserId,
                    BoardGameId = entity.BoardGameId,
                    Review = entity.Review,
                    IsReviewPrivate = entity.IsReviewPrivate,
                    Rating = entity.Rating
                };
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

        public IEnumerable<PlayList> GetPlaysByUserId(Guid userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Plays
                        .Where(e => e.UserId == _ownerId.ToString())
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

        public bool DeletePlay(int playId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Plays
                        .Single(e => e.PlayId == playId);
                ctx.Plays.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
