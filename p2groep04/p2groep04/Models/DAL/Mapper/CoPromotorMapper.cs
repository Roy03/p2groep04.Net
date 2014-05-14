using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using p2groep04.Models.Domain;

namespace p2groep04.Models.DAL.Mapper
{
    public class CoPromotorMapper : EntityTypeConfiguration<CoPromotor>
    {
        public CoPromotorMapper()
        {
            // Primary key
            HasKey(c => c.Id);

            // Properties
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.FirstName).IsRequired();
            Property(c => c.LastName).IsRequired();
            Property(c => c.Email).IsRequired();
            Property(c => c.Company).IsRequired();
            HasMany(c => c.Students).WithOptional(c => c.CoPromotor);
        }
        
    }
}