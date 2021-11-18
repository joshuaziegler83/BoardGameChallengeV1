using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameChallengeV1.Data
{
    public class FriendRequest
    {
        [Key]
        public int FriendRequestId { get; set; }
        public string UserId1 { get; set; }
        public virtual ApplicationUser ApplicationUser1 { get; set; }
        public string UserId2 { get; set; }
        public virtual ApplicationUser ApplicationUser2 { get; set; }
        public bool IsAccepted { get; set; }
    }
}
