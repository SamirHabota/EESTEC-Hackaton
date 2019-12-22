using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class Like
    {
        public int LikeId { get; set; }
        public string AccountId { get; set; }
        public int CommentId { get; set; }

        public Account Account { get; set; }
        public Comment Comment { get; set; }

    }
}
