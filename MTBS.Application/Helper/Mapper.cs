using AutoMapper;
using MTBS.Application.Features;
using MTBS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Application.Helper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Movie, MovieModel>().ReverseMap();
            CreateMap<Movie, AddMovieCommand>();
        }
    }
}
