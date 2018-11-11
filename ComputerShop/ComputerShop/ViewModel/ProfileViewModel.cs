using ComputerShop.Commands;
using ComputerShop.ConnectivityServices;
using ComputerShop.Core.Models;
using ComputerShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.ViewModel
{
    public class ProfileViewModel : BindableBase
    {
        private string _username;
        private string _password;
        private string _name;
        private string _surname;
        private string _msgLabel;
        public MyICommand ChangeCommand { get; set; }
        public MyICommand CancelCommand { get; set; }

        public ProfileViewModel()
        {
            ChangeCommand = new MyICommand(Change, CanChangeUser);
            CancelCommand = new MyICommand(Cancel);

            Initialize();
        }

        private void Initialize()
        {
            if (RuntimeContext.curentUser != null)
            {
                Username = RuntimeContext.curentUser.Username;
                Name = RuntimeContext.curentUser.Name;
                Surname = RuntimeContext.curentUser.Surname;
                Password = RuntimeContext.curentUser.Password;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged("Password");
                    ChangeCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged("Username");
                    ChangeCommand.RaiseCanExecuteChanged();
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
                    ChangeCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                if (_surname != value)
                {
                    _surname = value;
                    OnPropertyChanged("Surname");
                    ChangeCommand.RaiseCanExecuteChanged();
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

        private void Cancel()
        {
            LogService.Instance.LogInformation("Canceled viewing profile.");
            RuntimeContext.msgLabel = "Canceled profile view.";
            MainWindowViewModel.Instance.OnNav("data");
        }

        private bool CanChangeUser()
        {
            return !String.IsNullOrEmpty(_name) && !String.IsNullOrEmpty(_surname) && !String.IsNullOrEmpty(_username) && !String.IsNullOrEmpty(_password);
        }

        private void Change()
        {
            User newUser = new User
            {
                Name = Name,
                Surname = Surname,
                Password = Password,
                Username = Username,
                Id = RuntimeContext.curentUser.Id
            };

            if (ConnectionService.Instance.proxy.EditUser(newUser))
            {
                MsgLabel = "Your profile is changed in db!";
                RuntimeContext.msgLabel = "Your profile is changed in db!";
                LogService.Instance.LogInformation("Your profile is changed in db.");
                MainWindowViewModel.Instance.OnNav("data");
            }
            else
            {
                LogService.Instance.LogError("Error while changing profile.");
                MsgLabel = "Error while changing profile, please try again later!";
            }
        }
    }
}
