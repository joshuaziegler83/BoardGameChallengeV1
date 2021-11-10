using BoardGameChallengeV1.Data;
using BoardGameChallengeV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameChallengeV1.Services
{
    public class PlayService
    {
        private readonly Guid _userId;

        public PlayService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePlay(PlayCreate model)
        {
            var entity =
                new Play()
                {
                    UserId = _userId,
                    IsReviewPrivate = model.IsReviewPrivate,
                    Review = model.Review,
                    Rating = model.Rating
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Plays.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
