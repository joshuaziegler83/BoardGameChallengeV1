using BoardGameChallengeV1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameChallengeV1.Models
{
    public class FriendRequestDetail
    {
        public int FriendRequestId { get; set; }
        public string UserId1 { get; set; }
        public string UserId2 { get; set; }
        public bool IsAccepted { get; set; }
    }
}
