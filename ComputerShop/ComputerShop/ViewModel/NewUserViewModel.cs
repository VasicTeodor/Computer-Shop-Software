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
    public class NewUserViewModel : BindableBase
    {
        private string _username;
        private string _password;
        private string _name;
        private string _surname;
        private string _role;
        private string _msgLabel;
        private List<string> _roleList;
        public MyICommand AddUserCommand { get; set; }
        public MyICommand CancelCommand { get; set; }

        public NewUserViewModel()
        {
            AddUserCommand = new MyICommand(AddUser, CanAddUser);
            CancelCommand = new MyICommand(Cancel);

            RoleList = new List<string> { "admin", "user" };
        }

        public List<string> RoleList
        {
            get
            {
                return _roleList;
            }

            set
            {
                if(_roleList != value)
                {
                    _roleList = value;
                }
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
                    AddUserCommand.RaiseCanExecuteChanged();
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
                    AddUserCommand.RaiseCanExecuteChanged();
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
                    AddUserCommand.RaiseCanExecuteChanged();
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
                    AddUserCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string Role
        {
            get
            {
                return _role;
            }
            set
            {
                if (_role != value)
                {
                    _role = value;
                    OnPropertyChanged("Surname");
                    AddUserCommand.RaiseCanExecuteChanged();
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
            LogService.Instance.LogInformation("Canceled adding new user.");
            RuntimeContext.msgLabel = "Canceled adding new user.";
            MainWindowViewModel.Instance.OnNav("data");
        }

        private bool CanAddUser()
        {
            return !String.IsNullOrEmpty(_name) && !String.IsNullOrEmpty(_surname) && !String.IsNullOrEmpty(_username) && !String.IsNullOrEmpty(_password);
        }

        private void AddUser()
        {
            User newUser = new User
            {
                Name = Name,
                Surname = Surname,
                Password = Password,
                Username = Username,
                Role = Role
            };

            if (ConnectionService.Instance.proxy.AddNewUser(newUser))
            {
                RuntimeContext.msgLabel = "New user is added to db!";
                LogService.Instance.LogInformation("New user is added to db.");
                MainWindowViewModel.Instance.OnNav("data");
            }
            else
            {
                MsgLabel = "Error while adding new user, please try again later!";
                LogService.Instance.LogError("Error while adding new user.");
            }
        }
    }
}
