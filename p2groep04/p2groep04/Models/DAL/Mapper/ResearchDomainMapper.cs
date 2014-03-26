using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace p2groep04.Models.DAL.Mapper
{
    public class ResearchDomainMapper : EntityTypeConfiguration<ResearchDomain>
    {
        public ResearchDomainMapper()
        {
            HasKey(r => r.Id);
        }
    }
}