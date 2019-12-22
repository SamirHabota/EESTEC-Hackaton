using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Document
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string DocumentPath { get; set; }
        public string Extension { get; set; }
        public string OriginalAuthor { get; set; }
        public int LectureId { get; set; }
        public int TypeId { get; set; }

        public virtual Lecture Lecture { get; set; }
        public virtual Account OriginalAuthorNavigation { get; set; }
        public virtual DocumetType Type { get; set; }
    }
}
