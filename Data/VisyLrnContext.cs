using System.Linq;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Data
{
    public partial class VisyLrnContext : IdentityDbContext<Account>
    {
        public VisyLrnContext()
        {
        }

        public VisyLrnContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AccountGroup> AccountGroup { get; set; }
        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<Card> Card { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<DocumetType> DocumetType { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<Lecture> Lecture { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<Test> Test { get; set; }
        public virtual DbSet<TestQuestion> TestQuestion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

        }
    }
}
