using ComputerShop.Core;
using ComputerShop.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ComputerShop.Server.Access
{
    public class ComputerPartsRepository : IComputerPartsRepository
    {
        private static ComputerPartsRepository _instance;
        private ComputerPartsRepository() { }
        public static ComputerPartsRepository Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ComputerPartsRepository();

                return _instance;
            }
        }
        public bool AddComponent(Component component)
        {
            using(var dbContext = new ComputerPartsDBContext())
            {
                Component addedComponent = dbContext.Components.Add(component);
                dbContext.SaveChanges();

                return true;
            }
        }

        public StockComponent AddStockComponent(StockComponent stockComponent)
        {
            using (var dbContext = new ComputerPartsDBContext())
            {
                StockComponent addedStComponent = dbContext.StockComponents.Add(stockComponent);
                dbContext.SaveChanges();

                return addedStComponent;
            }
        }

        public bool DuplicateComponent(StockComponent component)
        {
            component.Id = new Guid();

            using(var dbContext = new ComputerPartsDBContext())
            {
                StockComponent stockComponent = dbContext.StockComponents.Add(component);
                dbContext.SaveChanges();

                return true;
            }
        }

        public bool EditComponent(Component component)
        {
            using (var dbContext = new ComputerPartsDBContext())
            {

                bool isInDb = dbContext.Components.Any(c => c.Id == component.Id);

                if (isInDb)
                {
                    var edit = dbContext.Components.FirstOrDefault(c => c.Id == component.Id);

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool EditStockComponent(StockComponent stockComponent)
        {
            using(var dbContext = new ComputerPartsDBContext())
            {
                var isInDb = dbContext.StockComponents.Any(c => c.Id == stockComponent.Id);
                if (isInDb)
                {
                    var component = dbContext.StockComponents.FirstOrDefault(c => c.Id == stockComponent.Id);
                    component.Count = stockComponent.Count;
                    component.PhysicalLocation = stockComponent.PhysicalLocation;
                    component.M_Component = stockComponent.M_Component;
                    component.Type = stockComponent.Type;

                    dbContext.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public IEnumerable<Component> GetComponents()
        {
            using(var dbContext = new ComputerPartsDBContext())
            {
                return dbContext.Components.ToList();
            }
        }

        public StockComponent GetStockComponent(Guid id)
        {
            using (var dbContext = new ComputerPartsDBContext())
            {
                var isInDb = dbContext.StockComponents.Any(c => c.Id == id);
                if (isInDb)
                {
                    return dbContext.StockComponents.Include(component => component.M_Component).FirstOrDefault(c => c.Id == id);
                }
                else
                {
                    return null;
                }
            }
        }

        public IEnumerable<StockComponent> GetStockComponents()
        {
            using(var dbContext = new ComputerPartsDBContext())
            {
                var components = dbContext.StockComponents
                                .Include(component => component.M_Component)
                                .ToList();
                return components;
            }
        }

        public bool RemoveComponent(Component component)
        {
            using (var dbContext = new ComputerPartsDBContext())
            {

                bool isInDb = dbContext.Components.Any(c => c.Id == component.Id);

                if (isInDb)
                {
                    var remove = dbContext.Components.FirstOrDefault(c => c.Id == component.Id);

                    dbContext.Components.Remove(remove);

                    dbContext.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool RemoveStockComponent(StockComponent stockComponent)
        {
            using (var dbContext = new ComputerPartsDBContext())
            {

                bool isInDb = dbContext.StockComponents.Any(c => c.Id == stockComponent.Id);

                if (isInDb)
                {
                    var remove = dbContext.StockComponents.FirstOrDefault(c => c.Id == stockComponent.Id);
                    
                    dbContext.StockComponents.Remove(remove);

                    dbContext.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
