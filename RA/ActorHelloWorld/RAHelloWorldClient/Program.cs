using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAHelloWorldClient
{
    using System.Threading;
    using HelloWorldActor.Interfaces;
    using Microsoft.ServiceFabric.Actors;
    using Microsoft.ServiceFabric.Actors.Client;

    class Program
    {
        static void Main(string[] args)
        {
            RunActorDemo().Wait();
        }
        public static async Task RunActorDemo()
        {

            // Create a randomly distributed actor ID
            ActorId actorId = new ActorId(Guid.Parse("{0F5C8934-3C26-457E-9239-B0B17BDB4CBD}"));

            // This only creates a proxy object, it does not activate an actor or invoke any methods yet.
            var myActor = ActorProxy.Create<IHelloWorldActor>(actorId, new Uri("fabric:/ActorHelloWorld/HelloWorldActorService"));


            // This will invoke a method on the actor. If an actor with the given ID does not exist, it will be activated by this method call.

            while(true)
            {
                var result = await myActor.SayHelloAsync("Ivan", CancellationToken.None);
                Console.WriteLine(result);
                Console.ReadLine();
            }

        }

    }
}
