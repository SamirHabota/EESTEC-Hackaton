using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class AccountGroup
    {
        public int Id { get; set; }
        public string AccountId { get; set; }
        public int GroupId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Group Group { get; set; }
    }
}
