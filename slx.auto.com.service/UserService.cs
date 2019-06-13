using MagicOnion;
using MagicOnion.Server;
using slx.auto.com.iservice;

namespace slx.auto.com.service
{
    public class UserService : ServiceBase<IUserService>, IUserService
    {
        private const int t = 3000;

        public UnaryResult<string> GetName(string name)
        {
            return new UnaryResult<string>($"This is {name}'s world!");
        }
    }
}
