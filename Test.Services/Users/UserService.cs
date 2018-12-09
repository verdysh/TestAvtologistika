using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Test.Data.Entities;
using Test.Services.Users.Dto;
using Test.Services.Utils;

namespace Test.Services.Users
{
    public class UserService : ServiceBase, IUserService
    {
        public UserDto Login(UserDto input)
        {
            var user = _unitOfWork.UsersRepository.Get(u => u.Email == input.Email).FirstOrDefault();
            if (user == null)
                return null;

            if(Md5Hash.GetHash(input.Password + user.PasswordSalt) != user.Password)
                return null;

            return Mapper.Map<UserDto>(user);
        }

        public UserDto RegisterUser(UserDto input)
        {
            var user = _unitOfWork.UsersRepository.Get(u => u.Email == input.Email).FirstOrDefault();
            if (user != null)
                return null;

            user = Mapper.Map<User>(input);
            user.PasswordSalt = Guid.NewGuid().ToString();
            user.Password = Md5Hash.GetHash(input.Password + user.PasswordSalt);
            _unitOfWork.UsersRepository.Insert(user);
            _unitOfWork.Save();

            return Mapper.Map<UserDto>(user);
        }
    }
}
