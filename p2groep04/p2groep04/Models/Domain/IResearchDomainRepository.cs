using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p2groep04.Models.Domain
{
    interface IResearchDomainRepository
    {
        IQueryable<ResearchDomain> FindAll();
        ResearchDomain FindBy(int id);
    }
}
