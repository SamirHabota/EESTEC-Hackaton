using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Data.Models
{
    public partial class Account : IdentityUser
    {
        public Account()
        {
            AccountGroup = new HashSet<AccountGroup>();
            Card = new HashSet<Card>();
            Comment = new HashSet<Comment>();
            Document = new HashSet<Document>();
            Group = new HashSet<Group>();
            Post = new HashSet<Post>();
            Subject = new HashSet<Subject>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int OrganizationId { get; set; }
        public int Year { get; set; }
        public int? VisyPoints { get; set; }
        public string AvatarLink { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual ICollection<AccountGroup> AccountGroup { get; set; }
        public virtual ICollection<Card> Card { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<Document> Document { get; set; }
        public virtual ICollection<Group> Group { get; set; }
        public virtual ICollection<Post> Post { get; set; }
        public virtual ICollection<Subject> Subject { get; set; }
    }
}
