using Grpc.Core;
using GRPCEmployeeService;
using IronFramework.GrpcService.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronFramework.GrpcService.Host
{
    /// <summary>
    /// Program
    /// </summary>
    class Program
    {
        public const int Port = 9007;

        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Server server = new Server
            {
                Services = { gRPC.BindService(new GrpcEmployeeServiceImpl()) },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine("gRPC server listening on port " + Port);
            Console.WriteLine("Press any key will exit...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
