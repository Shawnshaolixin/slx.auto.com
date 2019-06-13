using MagicOnion;

namespace slx.auto.com.iservice
{
    public interface IUserService : IService<IUserService>
    {
        UnaryResult<string> GetName(string name);
    }
}
