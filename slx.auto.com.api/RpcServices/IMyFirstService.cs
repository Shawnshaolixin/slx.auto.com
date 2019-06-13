using System;
using System.Threading;
using Grpc.Core;
using MagicOnion;
using MagicOnion.Server;

namespace slx.auto.com.api.RpcServices
{
    public interface IMyFirstService : IService<IMyFirstService>
    {
        UnaryResult<int> SumAsync(int x, int y);
    }
    public class MyFirstService : ServiceBase<IMyFirstService>, IMyFirstService
    {
        // You can use async syntax directly.
        public async UnaryResult<int> SumAsync(int x, int y)
        {
            Logger.Debug($"Received:{x}, {y}");

            return x + y;
        }

        public IMyFirstService WithCancellationToken(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public IMyFirstService WithDeadline(DateTime deadline)
        {
            throw new NotImplementedException();
        }

        public IMyFirstService WithHeaders(Metadata headers)
        {
            throw new NotImplementedException();
        }

        public IMyFirstService WithHost(string host)
        {
            throw new NotImplementedException();
        }

        public IMyFirstService WithOptions(CallOptions option)
        {
            throw new NotImplementedException();
        }
    }
}
