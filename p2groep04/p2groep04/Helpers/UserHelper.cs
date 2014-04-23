using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Security;
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

        public bool IsValidPassword(string username, string password)
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

        public bool IsValidEmail(string email)
        {
            //check if user can be found with email
            User user = _userRepository.FindByEmail(email);

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

        public string generatePassword(string email)
        {
            //Create a random password between 6 and 20 characters
            Random generator = new Random();
            int length = generator.Next(6,20);
            int numberOfNonAlphanumericCharacters = generator.Next(1, length);
            string password = Membership.GeneratePassword(length, numberOfNonAlphanumericCharacters);

            return password;
            
        }

        public string generateSaltPassword(string password, string email)
        {
            //check if user can be found with email
            User user = _userRepository.FindByEmail(email);

            //get salt of this user
            String salt = user.Salt;

            //rebuild pass
            string saltPassword = Encrypt(password + salt);

            return saltPassword;
        }

        public void sendMail(string password, string email)
        {
            var fromAddress = new MailAddress("Uw gmail account");
            var toAddress = new MailAddress(email);
            const string fromPassword = "Uw passwoord";
            const string subject = "New Password";
            string body = "Password: " + password;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }

        public void NotifyUser(User user, string email, string body, string subject)
        {
            var fromAddress = new MailAddress("Uw gmail account");
            var toAddress = new MailAddress(email);
            const string fromPassword = "Uw passwoord";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }


    }
}