using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Text { get; set; }
        public int AccountId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Post Post { get; set; }
    }
}
