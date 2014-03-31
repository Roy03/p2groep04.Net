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

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}