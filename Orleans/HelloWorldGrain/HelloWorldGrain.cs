using System;

namespace HelloWorldGrain
{
    using System.Threading;
    using System.Threading.Tasks;
    using Interfaces;
    using Orleans;
    public class HelloWorldGrain:Grain,IHelloWorldGrain
    {
        private int _counter;

        public async Task<string> SayHelloAsync(string name)
        {
            return await Task.FromResult($"Hello {name}. You are caller #{_counter++}");
        }
    }
}
