using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameChallengeV1.Data
{
    public class Play
    {
        [Key]
        public int PlayId { get; set; }
        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("BoardGame")]
        public int BoardGameId { get; set; }
        public virtual BoardGame BoardGame { get; set; }
        public string Review { get; set; }
        public bool IsReviewPrivate { get; set; }
        public double Rating { get; set; }
    }
}
