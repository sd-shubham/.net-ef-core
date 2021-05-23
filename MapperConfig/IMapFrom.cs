using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPIAndEfCore.MapperConfig
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile)
           => profile.CreateMap(typeof(T), GetType());
    }
}
