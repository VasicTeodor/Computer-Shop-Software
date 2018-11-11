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
    public class AddItemViewModel : BindableBase
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
        public AddItemViewModel()
        {
            AddItemComand = new MyICommand(AddItem, CanAddItem);
            CancelCommand = new MyICommand(Cancel);

            TypesList = new List<string> { "GPU", "CPU", "RAM", "Case", "Motherboard", "Memory" };
        }

        public List<string> TypesList
        {
            get
            {
                return _typesList;
            }

            set
            {
                if(_typesList != value)
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
                if(_msgLabel != value)
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

        public String Price
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

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if(_name != value)
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
            MainWindowViewModel.Instance.OnNav("data");
            LogService.Instance.LogInformation("Canceled adding new stock component.");
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
                newComponent.Id = new Guid();
                ConnectionService.Instance.proxy.AddComponent(newComponent);
                component.M_Component = newComponent;
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
            double help;
            decimal decHelp;

            if(!Count.All(c => c >= '0' && c <= '9'))
            {
                return false;
            }

            if(!decimal.TryParse(Price,out decHelp))
            {
                return false; 
            }

            switch (_componentType)
            {
                case "GPU":
                    return double.TryParse(InputOne,out help) && InputTwo.All(c => c >= '0' && c <= '9');
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
