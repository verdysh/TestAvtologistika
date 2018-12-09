using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data.Entities;
using Test.Services.Articles.Dto;
using Test.Services.Users.Dto;

namespace Test.Services
{
    public class ServicesMapper
    {
        public static void Configure(IMapperConfigurationExpression config)
        {
            config.CreateMap<User, UserDto>();

            config.CreateMap<UserDto, User>()
                .ForMember(u => u.PasswordSalt, opt => opt.Ignore());

            config.CreateMap<Article, ArticleDto>()
                .ForMember(
                    d => d.Date, 
                    o => o.MapFrom(
                        x => DateTimeOffset.FromUnixTimeSeconds(x.RowVer).DateTime.ToLocalTime()
                    )
                );
        }
    }
}
