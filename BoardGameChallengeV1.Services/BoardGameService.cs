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
                    UserId = _userId,
                    Name = model.Name,
                    Rating = model.Rating,
                    TimesPlayed = model.TimesPlayed
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.BoardGames.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<BoardGameList> GetAllBoardGames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .BoardGames
                        .Where(e=> e.UserId == _userId)
                        .Select(
                            e =>
                                new BoardGameList
                                {
                                    BoardGameId = e.BoardGameId,
                                    UserId = _userId,
                                    Name = e.Name,
                                    Rating = e.Rating,
                                    TimesPlayed = e.TimesPlayed
                                }
                                );
                return query.ToArray();
            }
        }

        public BoardGameDetail GetBoardGameById(int BoardGameId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .BoardGames
                        .Single(e => e.BoardGameId == BoardGameId && e.UserId == _userId);
                return
                    new BoardGameDetail
                    {
                        BoardGameId = entity.BoardGameId,
                        UserId = _userId,
                        Name = entity.Name,
                        Rating = entity.Rating,
                        TimesPlayed = entity.TimesPlayed
                    };
            }
        }

        public bool UpdateBoardGame(BoardGameEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                   ctx
                       .BoardGames
                       .Single(e => e.BoardGameId == model.BoardGameId && e.UserId == _userId);
                entity.BoardGameId = model.BoardGameId;
                entity.UserId = _userId;
                entity.Name = model.Name;
                entity.Rating = model.Rating;
                entity.TimesPlayed = model.TimesPlayed;
                return ctx.SaveChanges() == 1;
            }

        }

        public bool DeleteBoardGame(int BoardGameId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .BoardGames
                        .Single(e => e.BoardGameId == BoardGameId && e.UserId == _userId);
                ctx.BoardGames.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
