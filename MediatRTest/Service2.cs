using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;


namespace MediatRTest
{
    public class Service2 : IService2
    {
        private readonly ILogger _logger;
        private readonly IContext _context;
        public Service2(ILogger<Service2> logger, IContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task Method(string name)
        {
            _logger.LogDebug("当前用户:{0}", name);
            await Task.Delay(5000);
            //_logger.LogDebug("当前用户:{0}", _context.CurrentUser);
            _logger.LogDebug("Service2 Method at :{0}", DateTime.Now);
        }
    }
}
