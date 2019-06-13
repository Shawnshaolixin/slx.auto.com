using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public string Email { get; internal set; }
        public string PhoneNumber { get; internal set; }
    }
}
