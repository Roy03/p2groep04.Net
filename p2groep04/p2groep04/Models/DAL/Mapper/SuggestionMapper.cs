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
            Property(s => s.Subject).IsRequired().HasMaxLength(100);
            HasMany(s => s.ResearchDomains).WithMany(r => r.Suggestions).Map(m =>
            {
                m.ToTable("suggestion_researchdomain");
                m.MapLeftKey("suggestion_id");
                m.MapRightKey("researchdomain_id");
            });            
        }
    }
}