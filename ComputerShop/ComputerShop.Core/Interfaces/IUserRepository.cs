using ComputerShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Core.Interfaces
{
    public interface IUserRepository
    {
        User FindUser(string username);
        bool AddUser(User newUser);
        bool EditUser(User user);
        bool RemoveUser(User user);
    }
}
