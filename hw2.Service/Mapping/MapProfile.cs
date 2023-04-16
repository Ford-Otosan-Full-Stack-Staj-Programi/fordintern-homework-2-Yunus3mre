using AutoMapper;
using hw2.Core.Dtos;
using hw2.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2.Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Person,PersonDto>().ReverseMap();
        }
    }
}
