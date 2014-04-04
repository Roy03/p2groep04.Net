using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using p2groep04.Models.Domain;

namespace p2groep04.Helpers
{
    public class UserHelper
    {
        private readonly IUserRepository _userRepository ;

        public UserHelper(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public bool IsValid(string username, string password)
        {
            //get salt of this username
            String salt = _userRepository.FindSaltByUsername(username);

            if (salt == null)
            {
                return false;
            }

            //rebuild pass
            string saltPassword = Encrypt(password + salt);

            //check if user can be found with this salt
            User user = _userRepository.FindByUsernameAndPassword(username, saltPassword);

            return user != null;
        }

        public static string Encrypt(string password)
        {
            System.Security.Cryptography.SHA512Managed sha = new System.Security.Cryptography.SHA512Managed();
            byte[] hash = sha.ComputeHash(Encoding.ASCII.GetBytes(password));
            StringBuilder stringBuilder = new StringBuilder();

            foreach (byte b in hash)
            {
                stringBuilder.AppendFormat("{0:x2}", b);
            }
            return stringBuilder.ToString();
        }
    }
}