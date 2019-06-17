using System;

namespace MediatRTest
{
    public interface IContext
    {
        string CurrentUser { get; set; }
    }
}
