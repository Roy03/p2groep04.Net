using p2groep04.Models.Domain;
using System.Data.Entity;
using System.Linq;

namespace p2groep04.Models.DAL
{
    public class ResearchDomainRepository:IResearchDomainRepository
    {
        private ProjectContext context;
        private DbSet<ResearchDomain> researchDomains;

        public ResearchDomainRepository(ProjectContext context)
        {
            this.context = context;
            researchDomains = context.ResearchDomains;
        }

        public IQueryable<ResearchDomain> FindAll()
        {
            return researchDomains.OrderBy(r => r.Name);
        }

        public ResearchDomain FindBy(int id)
        {
            return researchDomains.SingleOrDefault(r => r.Id == id);
        }
    }
}