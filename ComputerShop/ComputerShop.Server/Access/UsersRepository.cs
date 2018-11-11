using ComputerShop.Core.Interfaces;
using ComputerShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Server.Access
{
    public class UsersRepository : IUserRepository
    {
        private static UsersRepository _instance;
        private UsersRepository() { }
        public static UsersRepository Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UsersRepository();

                return _instance;
            }
        }

        public bool AddUser(User newUser)
        {
            using(var dbContext = new ComputerPartsDBContext())
            {
                var isInDb = dbContext.Users.Any(u => u.Username.ToLower().Equals(newUser.Username.ToLower()));

                if (isInDb)
                {
                    return false;
                }

                User addedUser = dbContext.Users.Add(newUser);
                dbContext.SaveChanges();

                return true;
            }
        }

        public bool EditUser(User user)
        {
            using (var dbContext = new ComputerPartsDBContext())
            {
                var isInDb = dbContext.Users.Any(u => u.Username.ToLower().Equals(user.Username.ToLower()));

                if (isInDb)
                {
                    var edit = dbContext.Users.FirstOrDefault(u => u.Username.ToLower().Equals(user.Username.ToLower()));

                    edit.Name = user.Name;
                    edit.Password = user.Password;
                    edit.Role = user.Role;
                    edit.Surname = user.Surname;
                    edit.Username = user.Username;
                    
                    dbContext.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        public User FindUser(string username)
        {
            using (var dbContext = new ComputerPartsDBContext())
            {
                return dbContext.Users.FirstOrDefault(u => u.Username.ToLower().Equals(username.ToLower()));
            }
        }

        public bool RemoveUser(User user)
        {
            using(var dbContext = new ComputerPartsDBContext())
            {
                var isInDb = dbContext.Users.Any(u => u.Id == user.Id);
                if (isInDb)
                {
                    dbContext.Users.Remove(user);
                    dbContext.SaveChanges();

                    return true;
                }

                return false;
            }
        }
    }
}
