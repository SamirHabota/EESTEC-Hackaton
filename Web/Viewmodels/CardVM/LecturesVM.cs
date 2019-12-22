using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Viewmodels.CardVM
{
    public class LecturesVM
    {
        public List<Lecture> Lectures { get; set; }
        public List<Lecture> NoDups { get; set; }
    }
}
