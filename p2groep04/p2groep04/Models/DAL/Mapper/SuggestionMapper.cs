using System.Data.Entity.ModelConfiguration;
using p2groep04.Models.Domain;

namespace p2groep04.Models.DAL.Mapper
{
    public class SuggestionMapper : EntityTypeConfiguration<Suggestion>
    {
        public SuggestionMapper()
        {
            //Primary key
            HasKey(s => s.Id);

            //Properties
            Property(s => s.Title);
            Property(s => s.Subject);
            Property(s => s.Goal);
            Property(s => s.ResearchQuestion);
            Property(s => s.Motivation);
            Property(s => s.AdviceBPC).IsOptional();

            //HasRequired(s => s.Student).WithMany(s => s.Suggestions);
            HasMany(s => s.ResearchDomains).WithMany(s => s.Suggestions);
            HasMany(s => s.Feedbacks).WithRequired(s => s.Suggestion);

            //Property(s => s.CurrentState).IsRequired();

            //Relations
            /*HasMany(s => s.ResearchDomains).WithOptional().Map(m =>
            {
                m.ToTable("suggestion_researchdomain");
                m.MapLeftKey("suggestion_id");
                m.MapRightKey("researchdomain_id");
            });   */

            


        }
    }
}