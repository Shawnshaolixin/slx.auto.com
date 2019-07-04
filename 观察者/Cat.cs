namespace 观察者
{
    public class Cat : IObserver
    {
        public void Update(ISubject subject)
        {
            System.Console.WriteLine("猫跑了 。。。");
        }
    }
}
