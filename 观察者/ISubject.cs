namespace 观察者
{
    public interface ISubject
    {
        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);

        void NotifyAllObserver();
    }
}
