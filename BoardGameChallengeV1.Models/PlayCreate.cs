using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameChallengeV1.Models
{
    public class PlayCreate
    {
        [Required]
        public int PlayId { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public int BoardGameId { get; set; }
        public string Review { get; set; }
        public bool IsReviewPrivate { get; set; }
        public double Rating { get; set; }
    }
}
