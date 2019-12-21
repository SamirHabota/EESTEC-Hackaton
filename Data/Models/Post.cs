using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Post
    {
        public Post()
        {
            Comment = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public string AccountId { get; set; }
        public int GroupId { get; set; }
        public DateTime DateCreated {get; set;}

        public virtual Account Account { get; set; }
        public virtual Group Group { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
    }
}
