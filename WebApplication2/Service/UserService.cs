using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Model;

namespace WebApplication2.Service
{
    public class UserService
    {
        public UserDto FindUser(string name, string pwd)
        {
            return new UserDto
            {
                Password = "123456",
                UserName = "shaolixin",
                Email = "123@qq.com",
                Id = 1,
                Name = "shaolixin",
                PhoneNumber = "1388888888"

            };
        }
    }
}
