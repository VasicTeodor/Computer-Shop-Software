using ComputerShop.Commands;
using ComputerShop.ConnectivityServices;
using ComputerShop.Core.Models;
using ComputerShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ComputerShop.Services;

namespace ComputerShop.ViewModel
{
    public class StartViewModel : BindableBase
    {
        private string _username;
        private string _password;
        public MyICommand LogInCommand { get; set; }

        public StartViewModel()
        {
            LogInCommand = new MyICommand(LogIn,CanLogIn);
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
                    LogInCommand.RaiseCanExecuteChanged();
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
                    LogInCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private bool CanLogIn()
        {
            return (!string.IsNullOrWhiteSpace(_password) && !string.IsNullOrWhiteSpace(_username)) ;
        }

        public void LogIn()
        {
            User customer = ConnectionService.Instance.proxy.GetUser(Username);

            if (customer == null)
            {
                MessageBox.Show("Customer does not exist");
                return;
            }

            if (customer.Password.Equals(Password))
            {
                LogService.Instance.LogInformation("User loged in.");
                RuntimeContext.curentUser = customer;
                RuntimeContext.msgLabel = $"You have loged in as {customer.Role}.";
                MainWindowViewModel.Instance.OnNav("data");
            }
            else
            {
                LogService.Instance.LogError("Wrong password or username.");
                MessageBox.Show("Wrong Password");
            }
        }
    }
}
