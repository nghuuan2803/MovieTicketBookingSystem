using AutoMapper;
using MediatR;
using MTBS.Domain.Abstracts.Repositories;
using MTBS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Application.Features.Cinemas.Commands
{
    public class AddCinemaCommandHandler(ICinemaRepository repository, IMapper mapper)
        : IRequestHandler<AddCinemaCommand, Result<Cinema>>
    {
        public async Task<Result<Cinema>> Handle(AddCinemaCommand command, CancellationToken cancellationToken)
        {
            var cinema = mapper.Map<Cinema>(command.Request);
            cinema.CreatedAt = DateTimeOffset.Now;
            cinema.CreatedBy = command.UserName;
            await repository.AddAsync(cinema, cancellationToken);
            await repository.SaveAsync();
            return Result<Cinema>.Success(cinema);
        }
    }
}
