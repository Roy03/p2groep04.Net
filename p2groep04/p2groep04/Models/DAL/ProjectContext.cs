using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using p2groep04.Models.DAL.Mapper;
using p2groep04.Models.Domain;
using MySql.Data.Entity;

namespace p2groep04.Models.DAL
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
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
            Console.WriteLine("TEST");
            modelBuilder.Configurations.Add(new ResearchDomainMapper());
            modelBuilder.Configurations.Add(new SuggestionMapper());
            modelBuilder.Configurations.Add(new UserMapper());
            modelBuilder.Configurations.Add(new StudentMapper());
            modelBuilder.Ignore<SuggestionState>();

            modelBuilder.Entity<User>()
                .Map<Student>(m => m.Requires("Role").HasValue(1))
                .Map<Promotor>(m => m.Requires("Role").HasValue(2))
                .Map<BPCoordinator>(m => m.Requires("Role").HasValue(3));
        }
    }
}