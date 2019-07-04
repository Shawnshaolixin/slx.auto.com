namespace StackTraining
{
    public class Singleton
    {
        private Singleton()
        {

        }
        private static object obj = new object();
        private static Singleton Instance = GetInstance();
        public static Singleton GetInstance()
        {
            if (Instance == null)
            {
                lock (obj)
                {
                    if (Instance == null)
                    {
                        Instance = new Singleton();
                    }
                }
            }
            return Instance;
        }
    }
}
