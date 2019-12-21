using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Organization
    {
        public Organization()
        {
            Account = new HashSet<Account>();
            Subject = new HashSet<Subject>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Account> Account { get; set; }
        public virtual ICollection<Subject> Subject { get; set; }
    }
}
