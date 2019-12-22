using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Test
    {
        public Test()
        {
            TestQuestion = new HashSet<TestQuestion>();
        }

        public int Id { get; set; }
        public double TotalScore { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string AccountId {get; set;}
        public bool isFinished {get; set;}
        public int currentOrdinalNumber { get; set; }
        public double QuestionPoints {get; set;}

        public virtual ICollection<TestQuestion> TestQuestion { get; set; }
        public virtual Account Account {get; set;}
    }
}
