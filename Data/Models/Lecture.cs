using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Lecture
    {
        public Lecture()
        {
            Card = new HashSet<Card>();
            Document = new HashSet<Document>();
            Question = new HashSet<Question>();
        }

        public int Id { get; set; }
        public int? Number { get; set; }
        public string Name { get; set; }
        public int SubjectId { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual ICollection<Card> Card { get; set; }
        public virtual ICollection<Document> Document { get; set; }
        public virtual ICollection<Question> Question { get; set; }
    }
}
