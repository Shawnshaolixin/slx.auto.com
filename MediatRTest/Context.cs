using System;

namespace MediatRTest
{
    public class Context : IContext, IDisposable
    {
        public string CurrentUser { get; set; }

        public void Dispose()
        {
            
        }
    }
}
