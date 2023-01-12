using design_pattern.状态模式;
using System;

namespace design_pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            StatePatternDemo statePatternDemo = new StatePatternDemo();
            statePatternDemo.Init();

            Console.ReadKey();
        }
    }


}
