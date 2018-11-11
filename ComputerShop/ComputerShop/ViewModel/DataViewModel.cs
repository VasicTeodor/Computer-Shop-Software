using ComputerShop.Commands;
using ComputerShop.ConnectivityServices;
using ComputerShop.Core;
using ComputerShop.Services;
using ComputerShop.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ComputerShop.ViewModel
{
    public class DataViewModel : BindableBase,INotifyPropertyChanged
    {
        private string _searchText;
        private string _logMsg;
        private StockComponent _selectedStockComponent;
        private ObservableCollection<StockComponent> _stockComponents;
        public MyICommand LogOutCommand { get; set; }
        public MyICommand SearchCommand { get; set; }
        public MyICommand AddItemCommand { get; set; }
        public MyICommand AddUserCommand { get; set; }
        public MyICommand DuplicateCommand { get; set; }
        public MyICommand RefreshCommand { get; set; }
        public MyICommand ProfileCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand ViewItemCommand { get; set; }
        public MyICommand UndoCommand { get; set; }
        public MyICommand LogCommand { get; set; }

        public DataViewModel()
        {
            LogOutCommand = new MyICommand(LogOut);
            SearchCommand = new MyICommand(Search, CanSearch);
            AddUserCommand = new MyICommand(AddUser);
            ProfileCommand = new MyICommand(ViewProfile);
            AddItemCommand = new MyICommand(AddItem);
            DuplicateCommand = new MyICommand(Duplicate, CanDuplicate);
            RefreshCommand = new MyICommand(Refresh);
            DeleteCommand = new MyICommand(Delete, CanDelete);
            ViewItemCommand = new MyICommand(ViewItem, CanView);
            UndoCommand = new MyICommand(Undo);
            LogCommand = new MyICommand(Log);

            StockComponents = new ObservableCollection<StockComponent>();

            LogMsg = RuntimeContext.msgLabel;

            Initialize();

        }

        private void Check()
        {
            if (RuntimeContext.curentUser == null)
            {
                MainWindowViewModel.Instance.OnNav("home");
            }
        }

        public ObservableCollection<StockComponent> StockComponents
        {
            get
            {
                return _stockComponents;
            }
            set
            {
                _stockComponents = value;
                OnPropertyChanged("StockComponents");
            }
        }

        public StockComponent SelectedStockComponent
        {
            get
            {
                return _selectedStockComponent;
            }
            set
            {
                if(_selectedStockComponent != value)
                {
                    _selectedStockComponent = value;
                    DuplicateCommand.RaiseCanExecuteChanged();
                    DeleteCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string SearchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged("SearchText");
                    SearchCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string LogMsg
        {
            get
            {
                return _logMsg;
            }
            set
            {
                if(_logMsg != value)
                {
                    _logMsg = value;
                    OnPropertyChanged("LogMsg");
                }
            }
        }

        private void Search()
        {
            LogMsg = $"Searching for location: {SearchText}.";
            StockComponents = new ObservableCollection<StockComponent>(ConnectionService.Instance.proxy.SearchByLocation(SearchText));
            LogService.Instance.LogInformation($"Searching for {SearchText}");
        }
        private bool CanSearch()
        {
            return !String.IsNullOrEmpty(_searchText);
        }

        private void Duplicate()
        {
            StockComponent duplicate = (StockComponent)_selectedStockComponent.Clone();
            ConnectionService.Instance.proxy.DuplicateStockComponent(duplicate);
            Initialize();
            LogMsg = "Duplicated selected entry.";
            LogService.Instance.LogInformation("Duplicated selected entry.");
        }

        private bool CanDuplicate()
        {
            return (_selectedStockComponent != null);
        }

        private void Log()
        {
            LogService.Instance.LogInformation("Opened log window.");
            new LogView().Show();
        }

        private void Undo()
        {
            if (RuntimeContext.commands.Count == 0)
            {
                LogService.Instance.LogError("Undo failed.");
                return;
            }
            else if (RuntimeContext.commands.Last().Equals("delete") && RuntimeContext.deletedStockComponent == null)
            {
                LogService.Instance.LogError("Undo failed.");
                return;
            }
            else if (RuntimeContext.commands.Last().Equals("added") && RuntimeContext.addedStockComponent == null)
            {
                LogService.Instance.LogError("Undo failed.");
                return;
            }
            else
            {
                var operation = RuntimeContext.commands.Last();
                RuntimeContext.commands.RemoveAt(RuntimeContext.commands.Count - 1);

                if (RuntimeContext.commands.Count > 0)
                {
                    RuntimeContext.commands.Clear();
                }

                switch (operation)
                {
                    case "delete":
                        ConnectionService.Instance.proxy.AddComponent(RuntimeContext.deletedStockComponent.M_Component);
                        StockComponent stCmp = ConnectionService.Instance.proxy.AddStockComponent(RuntimeContext.deletedStockComponent);
                        RuntimeContext.addedStockComponent = stCmp;
                        RuntimeContext.commands.Add("added");
                        break;
                    case "added":
                        ConnectionService.Instance.proxy.DeleteStockComponent(RuntimeContext.addedStockComponent);
                        ConnectionService.Instance.proxy.DeleteComponent(RuntimeContext.addedStockComponent.M_Component);
                        RuntimeContext.deletedStockComponent = RuntimeContext.addedStockComponent;
                        RuntimeContext.commands.Add("delete");
                        break;
                }
            }
            Initialize();
            LogService.Instance.LogInformation("Undo executed.");
            LogMsg = "Undo.";
        }
        
        private void Delete()
        {
            if (ConnectionService.Instance.proxy.DeleteStockComponent(SelectedStockComponent))
            {
                var wtf = ConnectionService.Instance.proxy.DeleteComponent(SelectedStockComponent.M_Component);
                LogMsg = "Deleted selected entry.";
                LogService.Instance.LogInformation("Deleted selecteed entry.");
                RuntimeContext.deletedStockComponent = SelectedStockComponent;
                RuntimeContext.commands.Add("delete");
                Initialize();
            }
            else
            {
                MessageBox.Show("Selected item is allready deleted.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                LogService.Instance.LogError("Selected item is allready deleted.");
                Initialize();
                LogMsg = "Error while deleting selected entry.";
            }
        }

        private bool CanDelete()
        {
            return (_selectedStockComponent != null);
        }

        private void ViewItem()
        {
            RuntimeContext.selectedComponent = SelectedStockComponent;
            RuntimeContext.msgLabel = "Item details display.";
            LogService.Instance.LogInformation("Item details display.");
            LogMsg = "Item details display.";
            MainWindowViewModel.Instance.OnNav("viewItem");
        }

        private bool CanView()
        {
            return (_selectedStockComponent != null);
        }

        private void Refresh()
        {
            Initialize();
            LogMsg = "Updated values.";
            LogService.Instance.LogInformation("Refreshed values");
        }

        private void LogOut()
        {
            RuntimeContext.curentUser = null;
            LogService.Instance.LogInformation("User loged out.");
            MainWindowViewModel.Instance.OnNav("home");
        }

        private void AddUser()
        {
            RuntimeContext.msgLabel = "Adding new user.";
            LogService.Instance.LogInformation("Adding new user.");
            LogMsg = "Adding new user.";
            MainWindowViewModel.Instance.OnNav("newUser");
        }

        private void ViewProfile()
        {
            RuntimeContext.msgLabel = "Edit my profile.";
            LogService.Instance.LogInformation("Edit my profile.");
            LogMsg = "Edit my profile.";
            MainWindowViewModel.Instance.OnNav("editProfile");
        }

        private void AddItem()
        {
            RuntimeContext.msgLabel = "Adding new Item.";
            LogService.Instance.LogInformation("Adding new Item.");
            LogMsg = "Adding new Item.";
            if (MessageBox.Show("Do you want to add whole new component?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                MainWindowViewModel.Instance.OnNav("oldItem");
            }
            else
            {
                MainWindowViewModel.Instance.OnNav("addItem");
            }
        }

        private void Initialize()
        {
            StockComponents = new ObservableCollection<StockComponent>(ConnectionService.Instance.proxy.GetStockComponents());
            SelectedStockComponent = null;
        }
    }
}
