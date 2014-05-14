using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace p2groep04.Models.DAL.Mapper
{
    public class FeedbackMapper : EntityTypeConfiguration<Feedback>
    {
        public FeedbackMapper()
        {
            // Primary key
            HasKey(f => f.Id);

            // Properties
            Property(f => f.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(f => f.Inhoud).IsRequired();
            Property(f => f.CreatedOn).IsRequired();
            Property(f => f.Visable).IsRequired();
            
            HasRequired(f => f.Suggestion).WithMany(f => f.Feedbacks);
        }
    }
}