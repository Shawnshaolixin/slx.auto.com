using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System;

namespace AutoFacAopDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Start();
            //  Console.WriteLine("Hello World!");
        }
        static void Start()
        {
            var builder = new ContainerBuilder();
         //   builder.Register(c => new CallLogger(Console.Out)).Named<IInterceptor>("log-calls");
             builder.Register(c => new CallLogger(Console.Out));
            //  builder.RegisterType<Circle>().EnableClassInterceptors();
            //  builder.RegisterType<Circle>().EnableInterfaceInterceptors();
            //动态注入拦截器CallLogger
            builder.RegisterType<Circle>().InterceptedBy(typeof(CallLogger)).EnableClassInterceptors();
            var container = builder.Build();
            var svc = container.Resolve<Circle>();
            svc.Area();
            Console.ReadKey();
        }
    }
}
