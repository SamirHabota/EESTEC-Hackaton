using System.Collections.Generic;
using Web.Viewmodels.SharedVM;

namespace Web.Viewmodels.UserVM
{
    public class IndexVM
    {
        public List<SubjectVM> Subjects { get; set; }
        public UserDataVM User { get; set; }
    }
}

