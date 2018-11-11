using ComputerShop.Commands;
using ComputerShop.ConnectivityServices;
using ComputerShop.Core;
using ComputerShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.ViewModel
{
    public class AddOldItemViewModel : BindableBase
    {
        private string _count;
        private string _location;
        private string _msgLabel;
        private Component _selectedComponent;
        private List<Component> _componentList;

        public MyICommand AddItemComand { get; set; }
        public MyICommand CancelCommand { get; set; }

        public AddOldItemViewModel()
        {
            AddItemComand = new MyICommand(AddItem, CanAddItem);
            CancelCommand = new MyICommand(Cancel);
            ComponentList = new List<Component>();

            Init();
        }

        public List<Component> ComponentList
        {
            get
            {
                return _componentList;
            }
            set
            {
                if (_componentList != value)
                {
                    _componentList = value;
                    OnPropertyChanged("ComponentList");
                }
            }
        }

        public string MsgLabel
        {
            get
            {
                return _msgLabel;
            }
            set
            {
                if (_msgLabel != value)
                {
                    _msgLabel = value;
                    OnPropertyChanged("MsgLabel");
                }
            }
        }

        public Component SelectedComponent
        {
            get
            {
                return _selectedComponent;
            }
            set
            {
                if (_selectedComponent != value)
                {
                    _selectedComponent = value;
                    OnPropertyChanged("SelectedComponent");
                    AddItemComand.RaiseCanExecuteChanged();
                }
            }
        }

        public string Count
        {
            get
            {
                return _count;
            }
            set
            {
                if (_count != value)
                {
                    _count = value;
                    OnPropertyChanged("Count");
                    AddItemComand.RaiseCanExecuteChanged();
                }
            }
        }

        public string Location
        {
            get
            {
                return _location;
            }
            set
            {
                if (_location != value)
                {
                    _location = value;
                    OnPropertyChanged("Location");
                    AddItemComand.RaiseCanExecuteChanged();
                }
            }
        }

        private void Cancel()
        {
            MainWindowViewModel.Instance.OnNav("data");
            LogService.Instance.LogInformation("Canceled adding new stock component.");
        }

        private bool CanAddItem()
        {
            return !String.IsNullOrEmpty(_count) && !String.IsNullOrEmpty(_location);
        }

        private void AddItem()
        {
            if (CheckNumbers() && SelectedComponent != null)
            {
                var type = "";
                if (SelectedComponent.GetType().Name.Equals("MotherBoard"))
                {
                    type = "Motherboard";
                }
                else
                {
                    type = SelectedComponent.GetType().Name;
                }

                StockComponent component = new StockComponent
                {
                    Count = Int32.Parse(Count),
                    PhysicalLocation = Location,
                    Type = type
                };

                Component cmp = SelectedComponent;
                cmp.Id = new Guid();
                component.M_Component = cmp;
                ConnectionService.Instance.proxy.AddComponent(cmp);
                component.Id = new Guid();
                
                RuntimeContext.addedStockComponent = ConnectionService.Instance.proxy.AddStockComponent(component);
                RuntimeContext.msgLabel = "New stock item added to db.";
                RuntimeContext.commands.Add("added");
                LogService.Instance.LogInformation("New stock component added to db.");
                MainWindowViewModel.Instance.OnNav("data");
            }
            else
            {
                LogService.Instance.LogError("Wrong parameters.");
                MsgLabel = "Wrong number input.";
                return;
            }
        }

        private bool CheckNumbers()
        {
            if (!Count.All(c => c >= '0' && c <= '9'))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Init()
        {
            ComponentList = new List<Component>(ConnectionService.Instance.proxy.GetComponents());
        }
    }
}
