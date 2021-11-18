using BoardGameChallengeV1.Models;
using System.Collections.Generic;

namespace BoardGameChallengeV1.Services
{
    public interface IBoardGameService
    {
        bool CreateBoardGame(BoardGameCreate model);
        bool DeleteBoardGame(int BoardGameId);
        IEnumerable<BoardGameList> GetAllBoardGames();
        BoardGameDetail GetBoardGameById(int BoardGameId);
        bool UpdateBoardGame(BoardGameEdit model);
    }
}