using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Question
    {
        public Question()
        {
            Answer = new HashSet<Answer>();
            TestQuestion = new HashSet<TestQuestion>();
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public int LectureId { get; set; }
        public string OriginalAuthorId { get; set; }

        public virtual Lecture Lecture { get; set; }
        public virtual ICollection<Answer> Answer { get; set; }
        public virtual ICollection<TestQuestion> TestQuestion { get; set; }
    }
}
