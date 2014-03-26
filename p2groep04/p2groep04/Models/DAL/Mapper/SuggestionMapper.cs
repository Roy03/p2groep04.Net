using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace p2groep04.Models.DAL.Mapper
{
    public class SuggestionMapper : EntityTypeConfiguration<Suggestion>
    {
        public SuggestionMapper()
        {
            HasKey(s => s.Id);
            Property(s => s.Subject).IsRequired().HasMaxLength(100);
            HasRequired(s => s.ResearchDomain).WithMany().Map(m => m.MapKey("researchdomain_id")).WillCascadeOnDelete(false);
        }
    }
}