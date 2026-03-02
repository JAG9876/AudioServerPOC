namespace AudioCollectorPOC1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //ThreadPool.GetMinThreads(out int workerThreads, out int completionPortThreads); // Aspire 3 => 8,1
            //ThreadPool.SetMaxThreads(workerThreads, completionPortThreads);
            IHost host = CreateHostBuilder(args).Build();
            host.Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<StartUp>();
                });
        }
    }
}
