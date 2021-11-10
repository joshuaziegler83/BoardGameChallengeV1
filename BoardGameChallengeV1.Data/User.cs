using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameChallengeV1.Data
{
    public class User 
    {
        public Guid userId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public virtual ICollection<Friend> User1Friends { get; set; }
        public virtual ICollection<Friend> User2Friends { get; set; }
        public virtual ICollection<Play> Plays { get; set; }
    }
}
