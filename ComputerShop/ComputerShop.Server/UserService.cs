using ComputerShop.Core;
using ComputerShop.Server.Access;
using ComputerShop.Core.Interfaces;
using ComputerShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Server
{
    class UserService : IUserServices
    {
        public bool AddComponent(Component component)
        {
            return ComputerPartsRepository.Instance.AddComponent(component);
        }

        public bool AddNewUser(User user)
        {
            return UsersRepository.Instance.AddUser(user);
        }

        public StockComponent AddStockComponent(StockComponent stock)
        {
            return ComputerPartsRepository.Instance.AddStockComponent(stock);
        }

        public bool DeleteComponent(Component component)
        {
            return ComputerPartsRepository.Instance.RemoveComponent(component);
        }

        public bool DeleteStockComponent(StockComponent stockComponent)
        {
            return ComputerPartsRepository.Instance.RemoveStockComponent(stockComponent);
        }

        public bool DuplicateStockComponent(StockComponent stockComponent)
        {
            return ComputerPartsRepository.Instance.DuplicateComponent(stockComponent);
        }

        public bool EditComponent(Component component)
        {
            return ComputerPartsRepository.Instance.EditComponent(component);
        }

        public bool EditStockComponent(StockComponent stockComponent)
        {
            return ComputerPartsRepository.Instance.EditStockComponent(stockComponent);
        }

        public bool EditUser(User user)
        {
            return UsersRepository.Instance.EditUser(user);
        }

        public IEnumerable<Component> GetComponents()
        {
            return ComputerPartsRepository.Instance.GetComponents();
        }

        public StockComponent GetStockComponent(Guid id)
        {
            return ComputerPartsRepository.Instance.GetStockComponent(id);
        }

        public IEnumerable<StockComponent> GetStockComponents()
        {
            return ComputerPartsRepository.Instance.GetStockComponents();
        }

        public User GetUser(string username)
        {
            return UsersRepository.Instance.FindUser(username);
        }

        public IEnumerable<StockComponent> SearchByLocation(string location)
        {
            return ComputerPartsRepository.Instance.GetStockComponents().Where(c => c.PhysicalLocation.ToLower().Contains(location.ToLower()));
        }
    }
}
