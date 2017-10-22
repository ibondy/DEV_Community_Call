using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrleansHelloWorldClient
{
    using System.Threading;
    using HelloWorldGrain.Interfaces;
    using Orleans;
    using Orleans.Runtime.Configuration;

    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
            Console.ReadLine();
        }

        public static async Task RunAsync()
        {
            var config = ClientConfiguration.LocalhostSilo();
            var builder = new ClientBuilder().UseConfiguration(config);
            var client = builder.Build();
            await client.Connect();
            Console.WriteLine("Connected to silo");

            var grain = client.GetGrain<IHelloWorldGrain>(00);

            while (true)
            {
               var result = await grain.SayHelloAsync("ivan");
                Console.WriteLine(result);
                Console.ReadLine();
            }
        }


    }
}
