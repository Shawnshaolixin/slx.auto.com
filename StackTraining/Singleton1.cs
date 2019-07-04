namespace StackTraining
{
    public class Singleton1
    {
        private static Singleton1 Instance = new Singleton1();
        private Singleton1() { }

        public static Singleton1 GetInstance()
        {
            return Instance;
        }
    }
}
