using System;
using System.Reflection;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFile(@"C:\Project\slx.auto.com\ConsoleApp7\bin\Debug\netcoreapp3.1\MyTestAssembly.dll");
            //Type[] types = assembly.GetTypes();
            //for (int i = 0; i < types.Length; i++)
            //{
            //    Console.WriteLine(types[i].Name);
            //}
            Type t = assembly.GetType("MyTestAssembly.Class1");
            var instance = Activator.CreateInstance(t);
            MethodInfo method = t.GetMethod("Add");
            var result = method.Invoke(instance, new object[] { 10, 20 });
            Console.WriteLine("result=" + result);
            Console.ReadKey();
        }
    }
}
