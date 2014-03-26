using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using p2groep04.Models.Domain;

namespace p2groep04.Models.DAL.Mapper
{
    public class StudentMapper : EntityTypeConfiguration<Student>
    {
        public StudentMapper()
        {
            HasKey(s => s.Id);
            Property(s => s.FirstName).IsRequired().HasMaxLength(50);
            Property(s => s.LastName).IsRequired().HasMaxLength(50);
            Property(s => s.Email).IsRequired();
            Property(s => s.Password).IsRequired();
            HasOptional(s => s.Suggestion).WithRequired().Map(su => su.MapKey("suggestion_id")).WillCascadeOnDelete(false);
        }
    }
}