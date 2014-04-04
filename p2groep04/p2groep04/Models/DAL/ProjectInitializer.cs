using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using p2groep04.Models.Domain;
using WebMatrix.WebData;

namespace p2groep04.Models.DAL
{
    //class ProjectInitializer : CreateAndMigrateDatabaseInitializer<ProjectContext, p2groep04.Migrations.Configuration>
    public class ProjectInitializer : DropCreateDatabaseAlways<ProjectContext>
    {

        protected override void Seed(ProjectContext context)
        {            
            try
            {
                // initialize database
                //context.Database.Initialize(true);
                Student studentMaxim = new Student()
                {
                    Id = 1,
                    Email = "maximgeerinck@hotmail.com",
                    FirstName = "Maxim",
                    LastName = "Geerinck",
                    Password = "fb30c5bae9be9322fc844655e4cfc2078f5a20217e29b7247c1da194984a8deb67edfa8e174a8b554f96eaa3b27848bd33cbacee26b2dc1644c5803a16e44751",
                    Salt = "Unknown",
                    Username = "209452mg"
                };
                
                List<Student> studenten = (new Student[] {studentMaxim}).ToList();
                studenten.ForEach(s => context.Users.Add(s));
                context.SaveChanges();
                System.Diagnostics.Debug.WriteLine("Database created!");                                

            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine("Een errortje in initializer");
            }
        }
    }
}