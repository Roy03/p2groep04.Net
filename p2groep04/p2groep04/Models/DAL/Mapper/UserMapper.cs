﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using System.Web.UI;
using p2groep04.Models.Domain;

namespace p2groep04.Models.DAL.Mapper
{
    public class UserMapper : EntityTypeConfiguration<User>
    {
        public UserMapper()
        {
            ToTable("user");  
            
            // Primary key
            HasKey(u => u.Id);

            // Properties
            Property(u => u.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(u => u.FirstName).IsRequired();
            Property(u => u.LastName).IsRequired();
            Property(u => u.Email).IsRequired();
            Property(u => u.Salt).IsRequired();
            Property(u => u.Username).IsRequired();
            Property(u => u.Password).IsRequired();
            Property(u => u.LastLogin);
            Property(u => u.LastIp);
            Property(u => u.CreationDate).IsRequired();
            Property(u => u.LastPasswordChangedDate).IsRequired();

            //Map<Student>(m => m.Requires("Discriminator").HasValue("Student"));
            //Map<BPCoordinator>(m => m.Requires("Discriminator").HasValue("BPCoordinator"));
            //Map<Promotor>(m => m.Requires("Discriminator").HasValue("Promotor"));

          
        }
    }
}