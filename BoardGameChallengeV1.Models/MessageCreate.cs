using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameChallengeV1.Models
{
    public class MessageCreate
    {
        public int MessageId { get; set; }
        public Guid UserId1 { get; set; }
        public Guid UserId2 { get; set; }
        public string Content { get; set; }
    }
}
