using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using p2groep04.Models.DAL.Mapper;
using p2groep04.Models.Domain;

namespace p2groep04.Models.DAL
{
    public class ProjectContext : DbContext
    {
        public ProjectContext() : base("Projecten2")
        {            
        }

        public DbSet<Student> Studenten { get; set; }
        public DbSet<Suggestion> Suggestions { get; set; }
        public DbSet<ResearchDomain> ResearchDomains{ get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ResearchDomainMapper());
            modelBuilder.Configurations.Add(new SuggestionMapper());
            modelBuilder.Configurations.Add(new UserMapper());


            modelBuilder.Entity<User>()
                .Map<Student>(m => m.Requires("Role").HasValue(1))
                .Map<Promotor>(m => m.Requires("Role").HasValue(2))
                .Map<BPCoordinator>(m => m.Requires("Role").HasValue(3));
        }
    }
}