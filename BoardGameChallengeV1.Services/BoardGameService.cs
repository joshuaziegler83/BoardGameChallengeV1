using BoardGameChallengeV1.Data;
using BoardGameChallengeV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameChallengeV1.Services
{
    public class BoardGameService
    {
        private readonly Guid _userId;

        public BoardGameService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateBoardGame(BoardGameCreate model)
        {
            var entity =
                new BoardGame()
                {
                    BoardGameId = model.BoardGameId,
                    Name = model.Name,
                    Rating = model.Rating,
                    TimesPlayed = model.TimesPlayed
                };
            using(var ctx = new ApplicationDbContext())
            {
                ctx.BoardGames.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
