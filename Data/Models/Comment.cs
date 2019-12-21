using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Text { get; set; }
        public string AccountId { get; set; }
        public DateTime DateCreated {get; set;}

        public virtual Account Account { get; set; }
        public virtual Post Post { get; set; }
    }
}
