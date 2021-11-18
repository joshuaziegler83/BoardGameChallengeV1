using BoardGameChallengeV1.Models;
using System;
using System.Collections.Generic;

namespace BoardGameChallengeV1.Services
{
    public interface IPlayService
    {
        bool CreatePlay(PlayCreate model);
        bool DeletePlay(int playId);
        PlayDetail GetPlay(int playId);
        IEnumerable<PlayList> GetPlaysByBoardGameId(int BoardGameId);
        IEnumerable<PlayList> GetPlaysByUserId(Guid userId);
        bool UpdatePlay(PlayEdit model);
    }
}