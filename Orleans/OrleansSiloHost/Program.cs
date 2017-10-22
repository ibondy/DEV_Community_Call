namespace OrleansSiloHost
{
    using System;
    using Orleans.Runtime.Configuration;

    /// <summary>
    /// Orleans test host
    /// </summary>
    public class Program
    {
        private static OrleansHostWrapper _hostWrapper;
        static int Main(string[] args)
        {
            int exitCode = StartSilo(args);

            Console.WriteLine("Press Enter to terminate...");
            Console.ReadLine();

            exitCode += ShutdownSilo();

            //either StartSilo or ShutdownSilo failed would result on a non-zero exit code. 
            return exitCode;
        }


        private static int StartSilo(string[] args)
        {
            // define the cluster configuration
            var config = ClusterConfiguration.LocalhostPrimarySilo();
            //config.AddMemoryStorageProvider();

            _hostWrapper = new OrleansHostWrapper(config, args);
            return _hostWrapper.Run();
        }

        private static int ShutdownSilo()
        {
            if (_hostWrapper != null)
            {
                return _hostWrapper.Stop();
            }
            return 0;
        }
    }
}
