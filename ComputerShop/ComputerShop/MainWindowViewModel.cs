using ComputerShop.Commands;
using ComputerShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop
{
    public class MainWindowViewModel : BindableBase
    {
        public MyICommand<string> NavCommand { get; private set; }
        private StartViewModel _startViewModel = new StartViewModel();
        private DataViewModel _dataViewModel = new DataViewModel();
        private NewUserViewModel _newUserViewModel = new NewUserViewModel();
        private ProfileViewModel _profileViewModel = new ProfileViewModel();
        private AddItemViewModel _addItemViewModel = new AddItemViewModel();
        private AddOldItemViewModel _addOldItemViewModel = new AddOldItemViewModel();
        private ItemDetailsViewModel _itemDetailsViewModel = new ItemDetailsViewModel();
        private BindableBase currentViewModel;

        private static MainWindowViewModel _instance;

        public static MainWindowViewModel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MainWindowViewModel();

                return _instance;
            }
        }
        public MainWindowViewModel()
        {
            NavCommand = new MyICommand<string>(OnNav);
            CurrentViewModel = _startViewModel;
        }

        public BindableBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                SetProperty(ref currentViewModel, value);
            }
        }

        public void OnNav(string destination)
        {
            switch (destination)
            {
                case "home":
                    CurrentViewModel = _startViewModel;
                    break;
                case "data":
                    CurrentViewModel = _dataViewModel;
                    break;
                case "newUser":
                    CurrentViewModel = _newUserViewModel;
                    break;
                case "editProfile":
                    CurrentViewModel = _profileViewModel;
                    break;
                case "addItem":
                    CurrentViewModel = _addItemViewModel;
                    break;
                case "oldItem":
                    CurrentViewModel = _addOldItemViewModel;
                    break;
                case "viewItem":
                    CurrentViewModel = _itemDetailsViewModel;
                    break;
            }
        }
    }
}
