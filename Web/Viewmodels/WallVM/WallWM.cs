using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Viewmodels.WallVM
{
    public class WallWM
    {
        public List<Group> Groups { get; set; }
        public List<Data.Models.Account> Accounts { get; set; }
        public List<int> LikedComms {get; set;}
        public List<int> DislikedComms {get; set;}
    }
}
