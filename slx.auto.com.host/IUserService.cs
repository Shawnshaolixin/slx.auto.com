using Surging.Core.CPlatform.Ioc;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace slx.auto.com.host
{
    [ServiceBundle("api/{Service}")]
    public interface IUserService :IServiceKey
    {
        Task<string> SayHello(string username);
    }
}
