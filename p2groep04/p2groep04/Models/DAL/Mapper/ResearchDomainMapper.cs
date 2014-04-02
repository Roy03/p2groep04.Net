using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using p2groep04.Models.Domain;

namespace p2groep04.Models.DAL.Mapper
{
    public class ResearchDomainMapper : EntityTypeConfiguration<ResearchDomain>
    {
        public ResearchDomainMapper()
        {
            ToTable("research");

            HasKey(r => r.Id);
            Property(t => t.Name).IsRequired();
            HasMany(s => s.Suggestions).WithMany(r => r.ResearchDomains).Map(m =>
            {
                m.ToTable("suggestion_researchdomain");
                m.MapLeftKey("suggestion_id");
                m.MapRightKey("researchdomain_id");
            });  
        }
    }
}