using ComputerShop.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Server
{
    class ConnectionService : IConnectionService
    {
        public static ServiceHost serviceHost;

        public ConnectionService()
        {
            serviceHost = new ServiceHost(typeof(UserService));
            serviceHost.AddServiceEndpoint(typeof(IUserServices), new NetTcpBinding(), new Uri("net.tcp://localhost:10101/IUserServices"));
        }
        public void EndConnection()
        {
            serviceHost.Close();
            Console.WriteLine("Service Connection is ended!");
        }

        public void StartConnection()
        {
            serviceHost.Open();
            Console.WriteLine("Service Connection is started!");
        }
    }
}
