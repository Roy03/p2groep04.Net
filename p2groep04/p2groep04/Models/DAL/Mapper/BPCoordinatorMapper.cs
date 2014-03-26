using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace p2groep04.Models.DAL.Mapper
{
    public class BPCoordinatorMapper : EntityTypeConfiguration<BPCoordinator>
    {
        public BPCoordinatorMapper()
        {
            HasKey(b => b.Id);
            Property(b => b.FirstName).IsRequired().HasMaxLength(50);
            Property(b => b.LastName).IsRequired().HasMaxLength(50);
            Property(b => b.Email).IsRequired();
            Property(b => b.Password).IsRequired();
        }
    }
}