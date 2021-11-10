﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameChallengeV1.Data
{
    public class Friend
    {
        [Key]
        public int FriendId { get; set; }
        [ForeignKey(nameof(User1))]
        public Guid UserId1 { get; set; }
        [ForeignKey(nameof(User2))]
        public Guid UserId2 { get; set; }
        public virtual User User1 { get; set; }
        public virtual User User2 { get; set; }
    }
}
