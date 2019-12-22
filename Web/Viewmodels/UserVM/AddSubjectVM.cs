using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Viewmodels.UserVM
{
    public class AddSubjectVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int OrganizationId { get; set; }
        public string AccountId { get; set; }
        public string SyllabusPath { get; set; }
        public string Professor { get; set; }
        public int? Ects { get; set; }
        public int? SemesterNumber { get; set; }
    }
}
