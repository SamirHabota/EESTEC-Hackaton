using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Viewmodels.SharedVM;

namespace Web.Viewmodels.UserVM
{
    public class LectureDetailsVM
    {
        public UserDataVM User { get; set; }

        public List<CardVM> Cards { get; set; }
        public List<DocumentVM> Documents { get; set; }
        public List<QuestionVM> Questions{ get; set; }
        public NewCardModel NewCard { get; set; }
        public string LectureName { get; set; }
        public string SubjectName { get; set; }


        public class NewCardModel
        {
            public string Question { get; set; }
            public string Answer { get; set; }
        }
    }
}
