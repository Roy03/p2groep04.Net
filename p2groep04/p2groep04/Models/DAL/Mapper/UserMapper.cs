using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using p2groep04.Models.Domain;

namespace p2groep04.Models.DAL.Mapper
{
    public class UserMapper: EntityTypeConfiguration<User>
    {
        public UserMapper()
        {
            // Primary key
            HasKey(u => u.Id);

            // Properties
            Property(u => u.FirstName).IsRequired().HasMaxLength(30);
            Property(u => u.LastName).IsRequired().HasMaxLength(30);
            Property(u => u.Email).IsRequired().HasMaxLength(50);
            Property(u => u.Salt).IsRequired().HasMaxLength(255);
            Property(u => u.Username).IsRequired().HasMaxLength(255);
            Property(u => u.Password).IsRequired().HasMaxLength(255);
            Property(u => u.LastLogin);
            Property(u => u.LastIp).HasMaxLength(255);
            Property(u => u.Role).IsRequired();
        }        
    }
}