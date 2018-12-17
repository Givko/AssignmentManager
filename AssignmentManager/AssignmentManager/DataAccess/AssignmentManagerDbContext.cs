using System.Data.Entity;
using AssignmentManager.Entities;

namespace AssignmentManager.DataAccess
{
    public class AssignmentManagerDbContext : DbContext
    {
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public AssignmentManagerDbContext()
            : base("AssignmentManagerDb")
        {

        }
    }
}