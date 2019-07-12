using MediatR;

namespace MediatRTest
{
    public class TestEvent : IRequest<string>
    {
        public TestEvent(int id)
        {
            this.Id = id;
        }
        public int Id { get; private set; }
    }
}
