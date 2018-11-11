using ComputerShop.Commands;
using ComputerShop.ConnectivityServices;
using ComputerShop.Core;
using ComputerShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ComputerShop.ViewModel
{
    public class ItemDetailsViewModel : BindableBase
    {
        private string _name;
        private string _model;
        private string _count;
        private string _componentType;
        private string _location;
        private string _msgLabel;
        private string _price;
        private List<string> _typesList;

        private string _inputOne;
        private string _inputTwo;

        public MyICommand AddItemComand { get; set; }
        public MyICommand CancelCommand { get; set; }
        public MyICommand RefreshCommand { get; set; }
        public ItemDetailsViewModel()
        {
            AddItemComand = new MyICommand(AddItem, CanAddItem);
            CancelCommand = new MyICommand(Cancel);
            RefreshCommand = new MyICommand(OnRefresh);

            TypesList = new List<string> { "GPU", "CPU", "RAM", "Case", "Motherboard", "Memory" };

            Initialize();
        }

        private void Initialize(StockComponent stockComponent = null)
        {
            if (stockComponent == null)
            {
                stockComponent = RuntimeContext.selectedComponent;
            }

            if(stockComponent != null)
            {
                Name = stockComponent.M_Component.Name;
                Model = stockComponent.M_Component.Model;
                Count = stockComponent.Count.ToString();
                ComponentType = stockComponent.Type;
                Location = stockComponent.PhysicalLocation;
                Price = stockComponent.M_Component.Price.ToString();

                switch (stockComponent.Type)
                {
                    case "GPU":
                        InputOne = ((GPU)stockComponent.M_Component).Memory;
                        InputTwo = ((GPU)stockComponent.M_Component).Speed;
                        break;
                    case "CPU":
                        InputTwo = ((CPU)stockComponent.M_Component).Cores.ToString();
                        InputOne = ((CPU)stockComponent.M_Component).Speed; 
                        break;
                    case "RAM":
                        InputTwo = ((RAM)stockComponent.M_Component).Size;
                        InputOne = ((RAM)stockComponent.M_Component).RamType;
                        break;
                    case "Case":
                        InputOne = ((Case)stockComponent.M_Component).CaseType;
                        break;
                    case "Motherboard":
                        InputOne = ((MotherBoard)stockComponent.M_Component).Socket;
                        break;
                    case "Memory":
                        InputOne = ((Memory)stockComponent.M_Component).MemoryType;
                        InputTwo = ((Memory)stockComponent.M_Component).Size;
                        break;
                }
            }
        }

        public List<string> TypesList
        {
            get
            {
                return _typesList;
            }

            set
            {
                if (_typesList != value)
                {
                    _typesList = value;
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

        public string InputOne
        {
            get
            {
                return _inputOne;
            }
            set
            {
                if (_inputOne != value)
                {
                    _inputOne = value;
                    OnPropertyChanged("InputOne");
                    AddItemComand.RaiseCanExecuteChanged();
                }
            }
        }

        public string InputTwo
        {
            get
            {
                return _inputTwo;
            }
            set
            {
                if (_inputTwo != value)
                {
                    _inputTwo = value;
                    OnPropertyChanged("InputTwo");
                    AddItemComand.RaiseCanExecuteChanged();
                }
            }
        }

        public string Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    OnPropertyChanged("Price");
                    AddItemComand.RaiseCanExecuteChanged();
                }
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
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

        public string Model
        {
            get
            {
                return _model;
            }
            set
            {
                if (_model != value)
                {
                    _model = value;
                    OnPropertyChanged("Model");
                    AddItemComand.RaiseCanExecuteChanged();
                }
            }
        }

        public string ComponentType
        {
            get
            {
                return _componentType;
            }
            set
            {
                if (_componentType != value)
                {
                    _componentType = value;
                    OnPropertyChanged("ComponentType");
                    AddItemComand.RaiseCanExecuteChanged();
                }
            }
        }

        private void Cancel()
        {
            LogService.Instance.LogInformation("Canceled edit and view of item.");
            MainWindowViewModel.Instance.OnNav("data");
        }

        private bool CanAddItem()
        {
            return !String.IsNullOrEmpty(_count) && !String.IsNullOrEmpty(_name) && !String.IsNullOrEmpty(_location) && !String.IsNullOrEmpty(_price);
        }

        private void AddItem()
        {
            if (CheckNumbers())
            {
                StockComponent component = new StockComponent
                {
                    Id = RuntimeContext.selectedComponent.Id,
                    Count = Int32.Parse(Count),
                    PhysicalLocation = Location,
                    Type = ComponentType
                };

                Component newComponent = null;
                switch (_componentType)
                {
                    case "GPU":
                        newComponent = new GPU
                        {
                            Model = Model,
                            Name = Name,
                            Memory = InputOne,
                            Speed = InputTwo
                        };
                        break;
                    case "CPU":
                        newComponent = new CPU
                        {
                            Model = Model,
                            Name = Name,
                            Cores = Int32.Parse(InputTwo),
                            Speed = InputOne
                        };
                        break;
                    case "RAM":
                        newComponent = new RAM
                        {
                            Model = Model,
                            Name = Name,
                            Size = InputTwo,
                            RamType = InputOne
                        };
                        break;
                    case "Case":
                        newComponent = new Case
                        {
                            Model = Model,
                            Name = Name,
                            CaseType = InputOne
                        };
                        break;
                    case "Motherboard":
                        newComponent = new MotherBoard
                        {
                            Model = Model,
                            Name = Name,
                            Socket = InputOne
                        };
                        break;
                    case "Memory":
                        newComponent = new Memory
                        {
                            Model = Model,
                            Name = Name,
                            MemoryType = InputOne,
                            Size = InputTwo
                        };
                        break;
                }

                decimal help;
                decimal.TryParse(Price, out help);

                newComponent.Price = help;
                newComponent.Id = RuntimeContext.selectedComponent.M_Component.Id;
                var editComp = ConnectionService.Instance.proxy.EditComponent(newComponent);
                component.M_Component = newComponent;
                var editStock = ConnectionService.Instance.proxy.EditStockComponent(component);

                if(editComp && editStock)
                {
                    RuntimeContext.msgLabel = "Edited stock item added to db.";
                    MainWindowViewModel.Instance.OnNav("data");
                    LogService.Instance.LogInformation("Edited stock item added to db.");
                }
                else
                {
                    LogService.Instance.LogError("Selected item is no longer in base.");

                    if (MessageBox.Show("Selected item is no longer in base. Do you wan't to add it?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                    {
                        RuntimeContext.msgLabel = "Item is not edited.";
                        LogService.Instance.LogError("Item is not edited.");
                        MainWindowViewModel.Instance.OnNav("data");
                    }
                    else
                    {
                        ConnectionService.Instance.proxy.AddComponent(newComponent);
                        ConnectionService.Instance.proxy.AddStockComponent(component);
                        LogService.Instance.LogInformation("Edited stock item added to db.");
                        RuntimeContext.msgLabel = "Edited stock item added to db.";
                        MainWindowViewModel.Instance.OnNav("data");
                    }
                }

            }
            else
            {
                LogService.Instance.LogInformation("Wrong number input.");
                MsgLabel = "Wrong number input.";
                return;
            }
        }

        private void OnRefresh()
        {
            LogService.Instance.LogInformation("Refresh item");
            var stck = ConnectionService.Instance.proxy.GetStockComponent(RuntimeContext.selectedComponent.Id);
            if(stck == null)
            {
                if (MessageBox.Show("Selected item is no longer in base. Do you wan't to keep editing it?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    RuntimeContext.msgLabel = "Item is not edited.";
                    LogService.Instance.LogError("Item is not edited.");
                    MainWindowViewModel.Instance.OnNav("data");
                }
                else
                {
                    LogService.Instance.LogInformation("Item is keept for editing.");
                }
            }
            else
            {
                LogService.Instance.LogInformation("Item data is refreshed.");
                Initialize(stck);
            }
        }

        private bool CheckNumbers()
        {
            double help;
            Decimal decHelp;

            if(!Count.All(c => c >= '0' && c <= '9'))
            {
                return false;
            }

            if(!decimal.TryParse(Price, out decHelp))
            {
                return false;
            }

            switch (_componentType)
            {
                case "GPU":
                    return double.TryParse(InputOne, out help) && InputTwo.All(c => c >= '0' && c <= '9');
                case "RAM":
                    return InputTwo.All(c => c >= '0' && c <= '9');
                case "CPU":
                    return double.TryParse(InputOne, out help) && InputTwo.All(c => c >= '0' && c <= '9');
                case "Memory":
                    return InputTwo.All(c => c >= '0' && c <= '9');
                default:
                    return true;
            }
        }
    }
}
