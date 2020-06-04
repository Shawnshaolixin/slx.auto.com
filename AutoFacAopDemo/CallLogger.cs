using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AutoFacAopDemo
{
    public class CallLogger : IInterceptor
    {
        TextWriter _output;
        public CallLogger(TextWriter output)
        {
            _output = output;
        }
        public void Intercept(IInvocation invocation)
        {
            _output.WriteLine($"正在调用的方法是{invocation.Method.Name},参数是{invocation.Arguments.Select(a => (a ?? "").ToString()).ToArray()}");

            invocation.Proceed();
            _output.WriteLine($"方法执行完毕，返回结果：{invocation.ReturnValue}");
        }
    }
}
