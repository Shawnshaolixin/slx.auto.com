using MediatR;
namespace MediatRTest
{
    public class SomeEvent : INotification
    {
        public string Name { get; set; }
    }
}
