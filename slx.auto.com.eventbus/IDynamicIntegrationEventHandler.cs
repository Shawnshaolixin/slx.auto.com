using System.Threading.Tasks;

namespace slx.auto.com.eventbus
{
    public interface IDynamicIntegrationEventHandler
    {
        Task Handle(dynamic eventData);
    }
}