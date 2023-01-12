using System;

namespace MyTestAssembly
{
    public class Class1 : BaseClass
    {
    }
    public class BaseClass
    {
        public int GetResult()
        {
            return 9;
        }
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}
