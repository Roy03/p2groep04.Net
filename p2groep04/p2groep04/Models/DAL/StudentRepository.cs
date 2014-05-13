using System.Data.Entity;
using System.Linq;
using p2groep04.Models.Domain;

namespace p2groep04.Models.DAL
{
    public class StudentRepository
    {
        private ProjectContext context;
        private DbSet<Student> Students;

        public StudentRepository(ProjectContext context)
        {
            this.context = context;
            Students = context.Students;
        }

        public IQueryable<Student> FindAll()
        {
            return Students.OrderBy(u => u.LastName).Include(s => s.Suggestions);
        }

        public Student FindBy(int id)
        {
            return Students.Include(s => s.Suggestions).FirstOrDefault(u => u.Id == id);
        }

        public Student FindBy(string name)
        {
            return Students.Include(s => s.Suggestions).FirstOrDefault(u => u.Username.ToLower() == name.ToLower());
        }

        public string FindSaltByStudentname(string username)
        {
            Student student = Students.Include(s => s.Suggestions).FirstOrDefault(u => u.Username.ToLower().Equals(username.ToLower()));
            if (student == null)
            {
                return null;
            }
            return student.Salt;            
        }

        public Student FindByStudentnameAndPassword(string username, string password)
        {
            return Students.FirstOrDefault(u => u.Username.ToLower().Equals(username.ToLower()) && u.Password.Equals(password));
        }

        public Student FindByEmail(string email)
        {
            return Students.Include(s => s.Suggestions).FirstOrDefault(u => u.Email.ToLower().Equals(email.ToLower()));
        }

        public bool ChangePassword(string username, string newpass)
        {
            Student student = FindBy(username);

            if (student == null)
                return false;

            student.Password = newpass;
            SaveChanges();

            return true;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}