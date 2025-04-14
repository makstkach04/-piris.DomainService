using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace piris.ServerHost
{
    internal class Program
    {
        public static void WaitKey(string message, ConsoleKey key)
        {
            do
            {
                Console.WriteLine(message);
            }
            while (Console.ReadKey().Key != key);
        }

        static void Main(string[] args)
        {
            var serviceAddress = "127.0.0.1:8080";
            var serverBinding = new NetTcpBinding();
            // Logger.WriteInfo($"Starting Host on net.tcp://{serviceAddress}");

            //AuthService 
            var authServiceHost = new
            ServiceHost(typeof(_piris.DomainService.AuthService), new
            Uri($"net.tcp://{serviceAddress}/authService"));

            authServiceHost.AddServiceEndpoint(typeof(_piris.DomainService.IAuthService), serverBinding, "");
            //Logger.WriteSuccess($"New Host on net.tcp://{serviceAddress}/authService");

            //CentralBankService 
            var centralBankServiceHost = new
            ServiceHost(typeof(_piris.DomainService.CentralBankService), new
            Uri($"net.tcp://{serviceAddress}/centralBankService"));

            centralBankServiceHost.AddServiceEndpoint(typeof(_piris.DomainService.ICentralBankService), serverBinding, "");
            //Logger.WriteSuccess($"New Host on net.tcp://{serviceAddress}/centralBankService");

            //PositionService 
            var positionServiceHost = new
            ServiceHost(typeof(_piris.DomainService.PositionService), new
            Uri($"net.tcp://{serviceAddress}/positionService"));

            positionServiceHost.AddServiceEndpoint(typeof(_piris.DomainService.IPositionService), serverBinding, "");
            //Logger.WriteSuccess($"New Host on net.tcp://{serviceAddress}/positionService");

            //DatabaseService 
            var databaseServiceHost = new
            ServiceHost(typeof(_piris.DomainService.DatabaseService), new
            Uri($"net.tcp://{serviceAddress}/databaseService"));

            databaseServiceHost.AddServiceEndpoint(typeof(_piris.DomainService.IDatabaseService), serverBinding, "");
            //Logger.WriteSuccess($"New Host on net.tcp://{serviceAddress}/databaseService");

            //Open Hosts 
            authServiceHost.Open();
            centralBankServiceHost.Open();
            positionServiceHost.Open();
            databaseServiceHost.Open();

            //Logger.WriteSuccess("All Hosts are started. We are ready!"); 
            //Logger.WriteStatus("Press ENTER key to close host");
            WaitKey($"Waiting for { ConsoleKey.Enter.ToString()}", ConsoleKey.Enter);

            authServiceHost.Close();
            centralBankServiceHost.Close();
            positionServiceHost.Close();
            databaseServiceHost.Close();

            //Logger.WriteSuccess("All Hosts are closed, goodbye!");

            Console.ReadKey();
        }
    }

    internal class NetTcpBinding
    {
        public NetTcpBinding()
        {
        }
    }
}

