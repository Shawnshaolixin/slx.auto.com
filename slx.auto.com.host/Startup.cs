using Autofac;
using Surging.Core.ServiceHosting.Startup;

namespace slx.auto.com.host
{
    public class Startup : IStartup
    {
        public void Configure(IContainer app)
        {

        }

        public IContainer ConfigureServices(ContainerBuilder services)
        {
            return services.Build();
        }
    }
}
