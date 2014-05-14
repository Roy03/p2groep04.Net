using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using p2groep04.Models.Domain;

namespace p2groep04.Models.DAL.Mapper
{
    public class PromotorMapper : EntityTypeConfiguration<Promotor>
    {
        public PromotorMapper()
        {  

            this.HasMany(p => p.Students).WithRequired(p => p.Promotor);
            
        }
    }
}