using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameChallengeV1.Models
{
    public class PlayList
    { 
        public int PlayId { get; set; }
        public Guid UserId { get; set; }
        public int BoardGameId { get; set; }
        public string Review { get; set; }
        public bool IsReviewPrivate { get; set; }
        public double Rating { get; set; }
    }
}
