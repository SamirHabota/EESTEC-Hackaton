﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Viewmodels.SharedVM;

namespace Web.Viewmodels.UserVM
{
    public class IndexVM
    {
        public List<SubjectVM> Subjects { get; set; }
        public UserDataVM User { get; set; }
        public AddSubjectVM NewSubject { get; set; }
        public List<SelectListItem> Organizations { get; set; }

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

