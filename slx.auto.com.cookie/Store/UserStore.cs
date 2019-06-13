using slx.auto.com.cookie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace slx.auto.com.cookie.Store
{
    public class UserStore
    {
        private static List<User> _users = new List<User>() {
        new User {  Id=1, Name="shaolixin", Password="123456", Email="alice@gmail.com", PhoneNumber="18800000001" },
        new User {  Id=1, Name="shawn", Password="123456", Email="bob@gmail.com", PhoneNumber="18800000002" }
    };

        public User FindUser(string userName, string password)
        {
            return _users.FirstOrDefault(_ => _.Name == userName && _.Password == password);
        }
    }
}
