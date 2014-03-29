using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using p2groep04.Models.Domain;

namespace p2groep04.Models.DAL
{
    public class ProjectInitializer : DropCreateDatabaseAlways<ProjectContext>
    {
        protected override void Seed(ProjectContext context)
        {
            try
            {
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
                studenten.ForEach(s => context.Studenten.Add(s));

                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine("Een errortje in initializer");
            }
        }
    }
}