using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Lecture = new HashSet<Lecture>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int OrganizationId { get; set; }
        public string AccountId { get; set; }
        public string SyllabusPath { get; set; }
        public string Professor { get; set; }
        public int? Ects { get; set; }
        public int? SemesterNumber { get; set; }

        public virtual Account Account { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ICollection<Lecture> Lecture { get; set; }
    }
}
