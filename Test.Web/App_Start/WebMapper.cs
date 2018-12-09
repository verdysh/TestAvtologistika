using AutoMapper;
using Microsoft.Ajax.Utilities;
using Test.Services.Users.Dto;
using Test.Web.Models;

namespace Test
{
    public class WebMapper
    {
        public static void Configure(IMapperConfigurationExpression config)
        {
            config.CreateMap<LoginModel, UserDto>()
                .ForMember(user => user.Id, opt => opt.Ignore());

            config.CreateMap<RegistrationModel, UserDto>()
                .ForMember(user => user.Id, opt => opt.Ignore());
        }
    }
}