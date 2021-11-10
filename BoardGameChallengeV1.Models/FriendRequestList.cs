using BoardGameChallengeV1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameChallengeV1.Models
{
    public class FriendRequestList
    {
        public int FriendRequestId { get; set; }
        public Guid UserId1 { get; set; }
        public Guid UserId2 { get; set; }
        public Message Message { get; set; }
        public bool isAccepted { get; set; }
    }
}
