using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using p2groep04.Models.Domain;

namespace p2groep04.Models.DAL
{
    public class StudentRepository:IStudentRepository
    {
        private ProjectContext context;
        private DbSet<Student> students;

        public StudentRepository(ProjectContext context)
        {
            this.context = context;
            students = context.Students;
        }

        public IQueryable<Student> FindAll()
        {
            return students.OrderBy(s => s.LastName);
        }

        public Student FindBy(int id)
        {
            return students.SingleOrDefault(s => s.Id == id);
        }

        public Student FindByName(string firstName)
        {
            return students.SingleOrDefault(s => s.FirstName == firstName);
        }
    }
}