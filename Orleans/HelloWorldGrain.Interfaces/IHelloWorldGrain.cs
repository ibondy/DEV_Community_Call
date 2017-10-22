using System;

namespace HelloWorldGrain.Interfaces
{
    using System.Threading;
    using System.Threading.Tasks;
    using Orleans;

    public interface IHelloWorldGrain: IGrainWithIntegerKey
    {
        Task<string> SayHelloAsync(string name);
    }
}
