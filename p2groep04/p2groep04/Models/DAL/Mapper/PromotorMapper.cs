using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace p2groep04.Models.DAL.Mapper
{
    public class PromotorMapper:EntityTypeConfiguration<Promotor>
    {
        public PromotorMapper()
        {
            HasKey(p => p.Id);
            Property(p => p.FirstName).IsRequired().HasMaxLength(50);
            Property(p => p.LastName).IsRequired().HasMaxLength(50);
            Property(p => p.Email).IsRequired();
            Property(p => p.Password).IsRequired();
        }
           
    }
}