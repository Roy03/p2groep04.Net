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
                    Password = "Trololol",
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