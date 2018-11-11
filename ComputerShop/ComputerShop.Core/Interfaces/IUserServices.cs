using ComputerShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Core.Interfaces
{
    [ServiceContract]
    public interface IUserServices
    {
        [OperationContract]
        User GetUser(string username);
        [OperationContract]
        bool AddNewUser(User user);
        [OperationContract]
        bool EditUser(User user);
        [OperationContract]
        bool AddComponent(Component component);
        [OperationContract]
        StockComponent AddStockComponent(StockComponent stock);
        [OperationContract]
        IEnumerable<StockComponent> GetStockComponents();
        [OperationContract]
        bool DuplicateStockComponent(StockComponent stockComponent);
        [OperationContract]
        bool DeleteStockComponent(StockComponent stockComponent);
        [OperationContract]
        IEnumerable<StockComponent> SearchByLocation(string location);
        [OperationContract]
        IEnumerable<Component> GetComponents();
        [OperationContract]
        bool EditStockComponent(StockComponent stockComponent);
        [OperationContract]
        bool EditComponent(Component component);
        [OperationContract]
        bool DeleteComponent(Component component);
        [OperationContract]
        StockComponent GetStockComponent(Guid id);
    }
}
