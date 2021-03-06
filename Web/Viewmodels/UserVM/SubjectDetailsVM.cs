﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Viewmodels.SharedVM;

namespace Web.Viewmodels.UserVM
{
    public class SubjectDetailsVM
    {
        public UserDataVM User { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public int? Number { get; set; }
        public int SubjectId { get; set; }
        public List<LectureVM> Lectures { get; set; }
        
    }
}
