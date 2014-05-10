using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Security;
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
                    Email = "maxim.geerinck.t9452@student.hogent.be",
                    FirstName = "Maxim",
                    LastName = "Geerinck",
                    Password = "fb30c5bae9be9322fc844655e4cfc2078f5a20217e29b7247c1da194984a8deb67edfa8e174a8b554f96eaa3b27848bd33cbacee26b2dc1644c5803a16e44751",
                    Salt = "Unknown",
                    Username = "209452mg",
                    CreationDate = new DateTime(2014, 4, 23),
                    LastPasswordChangedDate = new DateTime(2014, 4, 23)
                };

                Student studentLogan = new Student()
                {
                    Id = 2,
                    Email = "logan.dupont.t8134@student.hogent.be",
                    FirstName = "Logan",
                    LastName = "Dupont",
                    Password = "ef3c52f55940f352278b8595073c074ea91507b06e429892d8b116b90d4dbdb6d986870cec242e584327bda2a53d4174f52fe799207495101fccf2191ed38675",
                    Salt = "Unknown",
                    Username = "208134ld",
                    CreationDate = new DateTime(2014, 4, 23),
                    LastPasswordChangedDate = new DateTime(2014, 4, 23)
                };

                Student studentBram = new Student()
                {
                    Id = 3,
                    Email = "bram.baert.t9197@student.hogent.be",
                    FirstName = "Bram",
                    LastName = "Baert",
                    //wanker123
                    Password = "c8a85bf1e4b89b4fde9b9db777d9b9b842c4ab7f0492dfe72e6b33573062816428578264281f8153301c5e5aab31db02f6facd4df9a7bd0ae72e4de37049aed6",
                    Salt = "Unknown",
                    Username = "209197bb",
                    CreationDate = new DateTime(2014, 4, 23),
                    LastPasswordChangedDate = new DateTime(2014, 4, 23)
                };

                Student studentRoy = new Student()
                {
                    Id = 4,
                    Email = "roy.hollaners.t9164@student.hogent.be",
                    FirstName = "Roy",
                    LastName = "Hollanders",
                    Password = "082e1117b866e6de8a87c049e8b02a3455d633e5445ca4763591fe09a04139a5706088274d9d0d56f035988b1012930a0e69f773fe451845f9ec0fbf2adf9f29",
                    Salt = "Unknown",
                    Username = "209164rh",
                    CreationDate = new DateTime(2014, 4, 23),
                    LastPasswordChangedDate = new DateTime(2014, 4, 23)
                };

                Promotor promotor1 = new Promotor()
                {
                    Id = 5,
                    Email = "roy.hollaners.t9164@student.hogent.be",
                    FirstName = "Jan",
                    LastName = "Jaap",
                    //promotor
                    Password = "5d3bf4ca34663abbfff43e116c726c65ec100797678c66a61c6cfdee85a6b837192a24b9864fd70c1acfd1881fb7490b52d52683782def7e399b8ecbba8f5c77",
                    Salt = "Unknown",
                    Username = "JanJaap",
                    CreationDate = new DateTime(2014, 4, 23),
                    LastPasswordChangedDate = new DateTime(2014, 4, 23)
                };

                List<Student> studenten = (new Student[] {studentMaxim, studentLogan, studentBram,studentRoy}).ToList();
                studenten.ForEach(s => context.Users.Add(s));
                studenten.ForEach(s => promotor1.Students.Add(s));
                List<Promotor> promotors = (new Promotor[] { promotor1 }).ToList();
                promotors.ForEach(p => context.Users.Add(p));
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