using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data.Entities;
using Test.Services.Users.Dto;

namespace Test.Services.Users
{
    public interface IUserService
    {
        UserDto RegisterUser(UserDto user);
        UserDto Login(UserDto user);
    }
}
