using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using p2groep04.Models.Domain;

namespace p2groep04.Models.DAL
{
    public class UserRepository:IUserRepository
    {
        private ProjectContext context;
        private DbSet<User> users;

        public UserRepository(ProjectContext context)
        {
            this.context = context;
            users = context.Users;
        }

        public IQueryable<User> FindAll()
        {
            return users.OrderBy(u => u.LastName);
        }

        public User FindBy(int id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }

        public User FindBy(string name)
        {
            return users.FirstOrDefault(u => u.Username.ToLower() == name.ToLower());
        }

        public string FindSaltByUsername(string username)
        {
            User user = users.FirstOrDefault(u => u.Username.ToLower().Equals(username.ToLower()));
            if (user == null)
            {
                return null;
            }
            return user.Salt;            
        }

        public User FindByUsernameAndPassword(string username, string password)
        {
            return users.FirstOrDefault(u => u.Username.ToLower().Equals(username.ToLower()) && u.Password.Equals(password));
        }

        public User FindByEmail(string email)
        {
            return users.FirstOrDefault(u => u.Email.ToLower().Equals(email.ToLower()));
        }

        public bool ChangePassword(string username, string newpass)
        {
            User user = FindBy(username);

            if (user == null)
                return false;

            user.Password = newpass;
            SaveChanges();

            return true;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}