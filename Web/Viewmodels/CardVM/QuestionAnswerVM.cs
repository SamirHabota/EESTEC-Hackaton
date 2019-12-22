using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Viewmodels.CardVM
{
    public class QuestionAnswerVM
    {
       public int CardId { get; set; }
       public string Answer { get; set; }
       public string Question { get; set; }
        public string Lecture { get; set; }
        public string Color {get; set;}
    }
}
