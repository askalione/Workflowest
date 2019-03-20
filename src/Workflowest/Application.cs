using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Workflowest.Services;

namespace Workflowest
{
    class Application
    {
        private readonly ServiceProvider _serviceProvider;

        private Application()
        {
            var services = new ServiceCollection();
            ServicesConfig.Configure(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void Run()
        {
            try
            {
                var service = _serviceProvider.GetService<IService>();
                service.Start();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.ReadKey();
            }
        }
        
        public static void Startup()
        {
            var app = new Application();
            app.Run();
        }
    }
}
