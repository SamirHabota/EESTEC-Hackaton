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
        public string Name { get; set; }

        public virtual ICollection<Document> Document { get; set; }
    }
}
