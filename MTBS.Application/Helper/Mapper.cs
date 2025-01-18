using AutoMapper;
using MTBS.Domain.Entities;
using MTBS.Shared.CinemaDTOs;
using MTBS.Shared.HallDTOs;
using MTBS.Shared.MovieDTOs;
using MTBS.Shared.ShowTimeDTOs;

namespace MTBS.Application.Helper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Movie, MovieModel>().ReverseMap();
            CreateMap<AddCinemaRequest, Cinema>();
            CreateMap<AddHallRequest, Hall>();
            CreateMap<AddShowTimeRequest, ShowTime>();
            CreateMap<AddMovieRequest, Movie>();
            //CreateMap<Movie, AddMovieCommand>();
        }
    }
}
