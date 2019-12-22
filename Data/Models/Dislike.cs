using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class Dislike
    {
        public int DislikeId { get; set; }
        public string AccountId { get; set; }
        public int CommentId { get; set; }

        public Account Account { get; set; }
        public Comment Comment { get; set; }

    }
}
