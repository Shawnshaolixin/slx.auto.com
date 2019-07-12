using MediatR;
namespace MediatRTest
{
    public class SomeEvent : INotification
    {
        public SomeEvent(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
    }
}
