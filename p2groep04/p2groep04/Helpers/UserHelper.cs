using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using p2groep04.Models.Domain;

namespace p2groep04.Helpers
{
    public class UserHelper
    {
        private readonly IUserRepository _userRepository;

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
            string password;
            while (true)
            {
                int length = generator.Next(6, 20);
                int numberOfNonAlphanumericCharacters = generator.Next(1, length);
                password = Membership.GeneratePassword(length, numberOfNonAlphanumericCharacters);

                Match match = Regex.Match(password, @"^.*(?=.{6,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9]).*$");

                if (match.Success)
                {
                    break;
                }
            }
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
            var fromAddress = new MailAddress("project2hogent@gmail.com");
            var toAddress = new MailAddress(email);
            const string fromPassword = "C#Project";
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

        public static void NotifyUsers(List<User> users, string body, string subject)
        {
            var fromAddress = new MailAddress("project2hogent@gmail.com");
            const string fromPassword = "C#Project";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            foreach (var user in users)
            {
                var toAddress = new MailAddress(user.Email);
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

        public static void NotifyStakeholderSuggestionAccepted(User user)
        {
            var fromAddress = new MailAddress("project2hogent@gmail.com");
            const string fromPassword = "C#Project";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };


            var toAddress = new MailAddress(user.Email);
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = "Voorstel geaccepteerd",
                Body = "Uw voorstel is geaccepteerd"
            })

                smtp.Send(message);
        }

        public static void NotifyStakeholderSuggestionDeclined(User user)
        {
            var fromAddress = new MailAddress("project2hogent@gmail.com");
            const string fromPassword = "C#Project";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };


            var toAddress = new MailAddress(user.Email);
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = "Voorstel geweigerd",
                Body = "Uw voorstel is geweigerd"
            })

                smtp.Send(message);
        }

        public static void NotifyStakeholderAdviceBpcNeeded(User user)
        {
            var fromAddress = new MailAddress("project2hogent@gmail.com");
            const string fromPassword = "C#Project";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };


            var toAddress = new MailAddress(user.Email);
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = "Advies gevraagd",
                Body = "Er wordt gevraagd voor advies"
            })

                smtp.Send(message);
        }

        public static void NotifyStakeholderSuggestionAcceptedWithRemarks(User user)
        {
            var fromAddress = new MailAddress("project2hogent@gmail.com");
            const string fromPassword = "C#Project";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };


            var toAddress = new MailAddress(user.Email);
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = "Voorstel geaccepteerd met opmerkingen",
                Body = "Uw voorstel is geaccepteerd maar er zijn opmerkingen"
            })

                smtp.Send(message);
        }

        public static void NotifyStakeholdersBpcHasGivenAdvice(User user)
        {
            var fromAddress = new MailAddress("project2hogent@gmail.com");
            const string fromPassword = "C#Project";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            var users = new List<User>();
            Student student = (Student) user;
            users.Add(student);
            users.Add(student.Promotor);

            foreach (var aUser in users)
            {
                var toAddress = new MailAddress(aUser.Email);
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = "BPC advies",
                    Body = "De BPC heeft advies gegeven"
                })
                {
                    smtp.Send(message);
                }
            }
        }


        public HashSet<char> GiveSpecialCharacters()
        {
            HashSet<char> specialCharacters = new HashSet<char>();
            specialCharacters.Add((char)33);
            for (int i = 35; i <= 47; i++)
            {
                specialCharacters.Add((char)i);
            }
            for (int i = 91; i <= 95; i++)
            {
                specialCharacters.Add((char)i);
            }
            for (int i = 123; i <= 126; i++)
            {
                specialCharacters.Add((char)i);
            }
            return specialCharacters;

        }

        public int giveCondition(string password)
        {
            HashSet<char> specialCharacters = GiveSpecialCharacters();
            string newPassword = password;

            int conditionCount = 0;
            if (newPassword.Any(char.IsLower))
                conditionCount++;
            if (newPassword.Any(char.IsUpper))
                conditionCount++;
            if (newPassword.Any(char.IsDigit))
                conditionCount++;
            if (newPassword.Any(specialCharacters.Contains))
                conditionCount++;

            return conditionCount;
        }
    }
}