using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace p2groep04.Models.Domain
{
    public interface IUserRepository
    {
        IQueryable<User> FindAll();
        User FindBy(int id);
        User FindBy(string name);
        string FindSaltByUsername(string username);
        User FindByUsernameAndPassword(string username, string password);
        User FindByUsernameAndEmail(string username, string email);
        bool ChangePassword(string username, string newpass);
        void SaveChanges();
        
    }
}