using System.Collections.Generic;

namespace 观察者
{
    public class Kid : ISubject
    {
        List<IObserver> list = new List<IObserver>();
        public void AddObserver(IObserver observer)
        {
            list.Add(observer);
        }

        public void NotifyAllObserver()
        {
            foreach (var item in list)
            {
                item.Update(new Kid());
            }
        }

        public void RemoveObserver(IObserver observer)
        {
            list.Remove(observer);
        }

        public void Cloud()
        {
            System.Console.WriteLine("小孩哭了");
            NotifyAllObserver();
        }
    }
}
