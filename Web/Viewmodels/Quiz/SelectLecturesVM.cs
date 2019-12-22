using System.Collections.Generic;

namespace Web.Viewmodels.Quiz
{
    public class SelectLecturesVM
    {
        public List<Subject> Subjects {get; set;}
        public List<int> Lectures {get; set;}

        public class Subject{
            public List <Lecture> Lectures {get; set;}
            public string Name {get; set;}
            public int Id {get; set;}
        }

        public class Lecture{
            public string Name {get; set;}
            public int Id {get; set;}
        }
    }
}