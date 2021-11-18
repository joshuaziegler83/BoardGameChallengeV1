using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameChallengeV1.Models
{
    public class BoardGameDetail
    {
        public int BoardGameId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public int TimesPlayed { get; set; }
    }
}
