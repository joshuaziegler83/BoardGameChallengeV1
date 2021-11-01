using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameChallengeV1.Data
{
    public class Play
    {
        [Key]
        public int PlayId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int BoardGameId { get; set; }
        [Required]
        public int TimesPlayed { get; set; }
        public string? Review { get; set; }
        [DefaultValue(false)]
        public bool IsReviewPrivate { get; set; }
        public double Rating { get; set; }
    }
}
