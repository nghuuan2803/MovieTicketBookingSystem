using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MTBS.Domain.Abstracts;
using MTBS.Domain.Abstracts.Repositories;
using MTBS.Domain.Entities;
using MTBS.Domain.SampleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Application.Features.ShowTimes.Commands
{
    public class AddShowTimeCommandHandler : IRequestHandler<AddShowTimeCommand, Result<ShowTime>>
    {
        private readonly IShowTimeRepository _showTimeRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IHallRepository _hallRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceProvider _serviceProvider;
        private List<Error> _errors;

        public AddShowTimeCommandHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
            _showTimeRepository = serviceProvider.GetRequiredService<IShowTimeRepository>();
            _movieRepository = serviceProvider.GetRequiredService<IMovieRepository>();
            _hallRepository = serviceProvider.GetRequiredService<IHallRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public async Task<Result<ShowTime>> Handle(AddShowTimeCommand command, CancellationToken cancellationToken)
        {
            var validator = new AddShowTimeValidator(_serviceProvider, command.Request);
            _errors = await validator.Validate();
            if (_errors.Count > 0)
            {
                return Result<ShowTime>.Failure(_errors);
            }

            var showTime = _mapper.Map<ShowTime>(command.Request);
            await SetEndTime(showTime, command.Request.MovieId);
            showTime.CreatedAt = DateTimeOffset.Now;
            showTime.CreatedBy = command.Sender;
            showTime.EndAt = showTime.BeginAt.AddMinutes(20);
            await CreateTickets(showTime);
            await _showTimeRepository.AddAsync(showTime);

            await _unitOfWork.BeginAsync();
            try
            {
                await _unitOfWork.CommitAsync();
                return Result<ShowTime>.Success(showTime);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollBackAsync();
                _errors = new() { new("db-error", ex.Message) };
                return Result<ShowTime>.Failure(_errors);
            }
        }

        private async Task CreateTickets(ShowTime showTime)
        {
            var hall = await _hallRepository.FindAsync(p => p.Id == showTime.HallId);
            if (hall.Seats == null || !hall.Seats.Any())
                throw new Exception("Phòng chiếu không có ghế.");
            showTime.Tickets = hall.Seats.Select(p => new Ticket
            {
                Status = 0, // 0: Open
                Price = 50000 * hall.PriceCoefficient * (p.PriceCoefficient), // Giá theo loại ghế
                SeatId = p.Id
            }).ToList();
        }

        private async Task SetEndTime(ShowTime showTime, int movieId)
        {
            var movie = await _movieRepository.FindAsync(movieId);
            showTime.EndAt = showTime.BeginAt.AddHours(20 + movie.Duration);
        }
    }
}
