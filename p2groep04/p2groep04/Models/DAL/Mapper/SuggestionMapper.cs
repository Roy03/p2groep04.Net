using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using p2groep04.Models.Domain;

namespace p2groep04.Models.DAL.Mapper
{
    public class SuggestionMapper : EntityTypeConfiguration<Suggestion>
    {
        public SuggestionMapper()
        {
            HasKey(s => s.Id);
            Property(s => s.Title).IsRequired().HasMaxLength(50);
            Property(s => s.Subject).IsRequired().HasMaxLength(100);
            Property(s => s.Goal).IsRequired().HasMaxLength(50);
            Property(s => s.ResearchQuestion).IsRequired().HasMaxLength(100);
            Property(s => s.Motivation).IsRequired().HasMaxLength(150);
            //Property(s => s.CurrentState).IsRequired();
            /*HasMany(s => s.ResearchDomains).WithOptional().Map(m =>
            {
                m.ToTable("suggestion_researchdomain");
                m.MapLeftKey("suggestion_id");
                m.MapRightKey("researchdomain_id");
            });   */         
        }
    }
}