using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace p2groep04.Models.DAL
{
    public class ProjectContext : DbContext
    {
        public ProjectContext():base("projecten2"){}

        public DbSet<Suggestion> Suggestions { get; set; }
        public DbSet<ResearchDomain> ResearchDomains{ get; set; }
        public DbSet<Promotor> Promotors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<BPCoordinator> BpCoordinators { get; set; } 
    }
}