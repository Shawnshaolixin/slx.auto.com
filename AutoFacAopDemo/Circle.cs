using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoFacAopDemo
{
    [Intercept(typeof(CallLogger))]
    public class Circle : ISharp
    {
        public void Area()
        {
            Console.WriteLine("正在调用圆的面积方法");
        }
    }
    public interface ISharp
    {
        void Area();
    }
}
