using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameChallengeV1.Models
{
    public class FriendCreate
    {
        public int FriendId { get; set; }
        public Guid UserId1 { get; set; }
        public Guid UserId2 { get; set; }
    }
}
