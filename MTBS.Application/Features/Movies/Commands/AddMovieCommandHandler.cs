using AutoMapper;
using MediatR;
using MTBS.Domain.Abstracts;
using MTBS.Domain.Abstracts.Repositories;
using MTBS.Domain.Entities;

namespace MTBS.Application.Features
{
    public class AddMovieCommandHandler(IUnitOfWork unitOfWork, 
        IMovieRepository movieRepository, IMapper mapper)
        : IRequestHandler<AddMovieCommand, Result<MovieModel>>
    {
        public async Task<Result<MovieModel>> Handle(AddMovieCommand request, 
            CancellationToken cancellationToken)
        {
            var movie = mapper.Map<Movie>(request);
            movie.CreatedAt = DateTimeOffset.Now;

            await movieRepository.AddAsync(movie);

            await unitOfWork.SaveChangesAsync();

            var model = mapper.Map<MovieModel>(movie);

            return Result<MovieModel>.Success(model);
        }
    }
}
