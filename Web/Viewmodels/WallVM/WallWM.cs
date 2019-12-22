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
        public List<Account> Accounts { get; set; }
    }
}
