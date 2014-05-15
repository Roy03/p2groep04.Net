using System.Data.Entity.ModelConfiguration;
using p2groep04.Models.Domain;

namespace p2groep04.Models.DAL.Mapper
{
    public class ResearchDomainMapper : EntityTypeConfiguration<ResearchDomain>
    {
        public ResearchDomainMapper()
        {
            ToTable("researchdomains");

            HasKey(r => r.Id);
            Property(r => r.Name).IsRequired();

            //HasMany(r => r.Suggestions).WithMany(r => r.ResearchDomains);
        }
    }
}