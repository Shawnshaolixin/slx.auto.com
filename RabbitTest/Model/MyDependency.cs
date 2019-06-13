using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace RabbitTest.Model
{
    public class MyDependency : IMyDependency
    {
        private readonly ILogger<MyDependency> _logger;
        public MyDependency(ILogger<MyDependency> logger)
        {
            _logger = logger;
        }
        public Task WriteMessage(string message)
        {
            _logger.LogInformation("MyDependency.WriteMessage called. Message: {MESSAGE}", message);
            return Task.FromResult(0);
        }
    }
    public interface IMyDependency
    {
        Task WriteMessage(string message);
    }
}
