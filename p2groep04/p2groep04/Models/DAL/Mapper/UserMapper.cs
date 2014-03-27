using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace p2groep04.Models.DAL.Mapper
{
    public class UserMapper: EntityTypeConfiguration<User>
    {
        public UserMapper()
        {
            HasKey(u => u.Id);
            Property(u => u.FirstName).IsRequired().HasMaxLength(30);
            Property(u => u.LastName).IsRequired().HasMaxLength(30);
            Property(u => u.Email).IsRequired().HasMaxLength(50);
        }
    }
}