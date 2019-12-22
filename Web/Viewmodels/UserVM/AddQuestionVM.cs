using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Viewmodels.UserVM
{
    public class AddQuestionVM
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public string AnswerOne { get; set; }
        public string AnswerTwo { get; set; }
        public string AnswerThree { get; set; }
        public string AnswerFour { get; set; }


        public bool IsAnswer { get; set; }
        public bool IsAnswerOne { get; set; }
        public bool IsAnswerTwo { get; set; }
        public bool IsAnswerThree { get; set; }
        public bool IsAnswerFour { get; set; }

        public int Id { get; set; }
    }
}
