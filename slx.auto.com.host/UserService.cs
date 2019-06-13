using Surging.Core.CPlatform.Ioc;
using Surging.Core.ProxyGenerator;
using System;
using System.Threading.Tasks;

namespace slx.auto.com.host
{
    [ModuleName("User")]
    public class UserService : ProxyServiceBase, IUserService
    {
        private UserRepository _repository;
        public UserService(UserRepository repository)
        {
            this._repository = repository;
        }

        public Task<string> SayHello(string username)
        {
            return Task.FromResult($"'{username}', Hello!");
        }
    }
}
