using BoardGameChallengeV1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameChallengeV1.Models
{
    public class BoardGameList
    {
        public int BoardGameId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public int TimesPlayed { get; set; }
        public ICollection<Play> Plays { get; set; }
    }
}
