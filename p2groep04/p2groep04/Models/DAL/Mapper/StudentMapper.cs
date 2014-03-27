using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using p2groep04.Models.Domain;

namespace p2groep04.Models.DAL.Mapper
{
    public class StudentMapper: EntityTypeConfiguration<Student>
    {
        public StudentMapper()
        {
            HasOptional(s => s.Suggestion).WithRequired().Map(su => su.MapKey("suggestion_id"));
        }
    }
}