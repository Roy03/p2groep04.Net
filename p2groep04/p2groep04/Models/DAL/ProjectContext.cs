using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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

        public DbSet<Suggestion> Suggestions { get; set; }
        public DbSet<ResearchDomain> ResearchDomains{ get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new ResearchDomainMapper());
            modelBuilder.Configurations.Add(new SuggestionMapper());
            modelBuilder.Configurations.Add(new UserMapper());
            modelBuilder.Configurations.Add(new FeedbackMapper());
        }
    }
}