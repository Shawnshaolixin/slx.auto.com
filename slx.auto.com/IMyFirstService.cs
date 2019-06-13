using MagicOnion;

namespace slx.auto.com
{
    public interface IMyFirstService : IService<IMyFirstService>
    {
        UnaryResult<int> SumAsync(int x, int y);
    }
}
