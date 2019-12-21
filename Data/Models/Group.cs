using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Group
    {
        public Group()
        {
            AccountGroup = new HashSet<AccountGroup>();
            Post = new HashSet<Post>();
        }

        public int Id { get; set; }
        public int CreatorId { get; set; }

        public virtual Account Creator { get; set; }
        public virtual ICollection<AccountGroup> AccountGroup { get; set; }
        public virtual ICollection<Post> Post { get; set; }
    }
}
