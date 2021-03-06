using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameChallengeV1.Data
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        public string Content { get; set; }
        public string UserId1 { get; set; }
        public virtual ApplicationUser User1 { get; set; }
        public string UserId2 { get; set; }
        public virtual ApplicationUser User2 { get; set; }
    }
}
