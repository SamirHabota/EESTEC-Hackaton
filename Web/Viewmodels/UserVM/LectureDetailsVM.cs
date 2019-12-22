using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Web.Viewmodels.SharedVM;

namespace Web.Viewmodels.UserVM
{
    public class LectureDetailsVM
    {
        public UserDataVM User { get; set; }

        public List<CardVM> Cards { get; set; }
        public List<DocumentVM> Documents { get; set; }
        public List<QuestionVM> Questions{ get; set; }
        public AddCardVM NewCard { get; set; }
        public string LectureName { get; set; }
        public int Id { get; set; }
        public string SubjectName { get; set; }
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


        public string Title { get; set; }
        public IFormFile File { get; set; }
        public string Description { get; set; }

    }
}
