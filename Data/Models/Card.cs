﻿using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Card
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public DateTime? LastShwon { get; set; }
        public Priority Priority { get; set; }
        public string OriginalAuthorId { get; set; }
        public int LectureId { get; set; }
        public string Color { get; set; }
        public virtual Lecture Lecture { get; set; }
        public virtual Account OriginalAuthor { get; set; }
    }

    public enum Priority {
        Low,
        Medium,
        High
    }
}
