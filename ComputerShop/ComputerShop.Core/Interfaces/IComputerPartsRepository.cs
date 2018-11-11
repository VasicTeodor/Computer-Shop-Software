using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Core.Interfaces
{
    public interface IComputerPartsRepository
    {
        StockComponent AddStockComponent(StockComponent stockComponent);
        bool RemoveStockComponent(StockComponent stockComponent);
        bool EditStockComponent(StockComponent stockComponent);
        IEnumerable<StockComponent> GetStockComponents();
        bool AddComponent(Component component);
        bool RemoveComponent(Component component);
        bool EditComponent(Component component);
        bool DuplicateComponent(StockComponent component);
        IEnumerable<Component> GetComponents();
        StockComponent GetStockComponent(Guid id);
    }
}
