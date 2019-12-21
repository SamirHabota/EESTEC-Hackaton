using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class DocumetType
    {
        public DocumetType()
        {
            Document = new HashSet<Document>();
        }

        public int Id { get; set; }
        public DocType Type {get; set;}

        public virtual ICollection<Document> Document { get; set; }
    }

    public enum DocType {
        Book,
        Script,
        Note
    }
}
