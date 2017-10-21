namespace HelloWorldActor
{
    using System.Threading;
    using System.Threading.Tasks;
    using Interfaces;
    using Microsoft.ServiceFabric.Actors;
    using Microsoft.ServiceFabric.Actors.Runtime;

    public class HelloWorldActor : Actor, IHelloWorldActor
    {
        private int _counter;

        public HelloWorldActor(ActorService actorService, ActorId actorId) : base(actorService, actorId)
        {
        }

        public async Task<string> SayHelloAsync(string name, CancellationToken cancellationToken)
        {
            return await Task.FromResult($"Hello {name}. You are caller #{_counter++}");
        }
    }
}