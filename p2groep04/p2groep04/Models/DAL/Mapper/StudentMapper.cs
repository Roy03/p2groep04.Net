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
            HasMany(s => s.Suggestions).WithRequired(s => s.Student);
            HasRequired(s => s.Promotor).WithMany(s => s.Students);
            HasOptional(s => s.CoPromotor).WithMany(s => s.Students);
            ToTable("user");
             
        }
     }
}