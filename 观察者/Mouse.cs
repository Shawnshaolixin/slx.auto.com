using System;

namespace 观察者
{
    public class Mouse : IObserver
    {
        public void Update(ISubject subject)
        {
            Console.WriteLine("老鼠也跑了");
        }
    }
}
