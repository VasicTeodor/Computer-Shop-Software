using ComputerShop.Commands;
using ComputerShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.ViewModel
{
    public class LogViewModel : BindableBase
    {
        private List<string> _logList;

        public MyICommand CloseCommand { get; set; }

        public LogViewModel()
        {
            CloseCommand = new MyICommand(Close);
            LogList = new List<string>();
            LogList = LogService.logApp;
        }

        public List<string> LogList
        {
            get
            {
                return _logList;
            }

            set
            {
                if(_logList != value)
                {
                    _logList = value;
                    OnPropertyChanged("LogList");
                }
            }
        }

        private void Close()
        {
            LogService.Instance.LogInformation("Closed log view.");
        }
    }
}
