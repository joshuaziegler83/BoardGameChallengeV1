using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameChallengeV1.Data
{
    public class BoardGame
    {
        [Key]
        public int BoardGameId { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public int TimesPlayed { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Play> Plays { get; set; }
    }
}
