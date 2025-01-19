using Microsoft.Extensions.DependencyInjection;
using MTBS.Domain.Abstracts.Repositories;
using MTBS.Domain.Entities;
using MTBS.Shared.ShowTimeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Application.Features.ShowTimes.Commands
{
    public class AddShowTimeValidator : AddShowTimeValidatorBase
    {
        private IHallRepository _hallRepository;
        private IMovieRepository _movieRepository;
        private IShowTimeRepository _showTimeRepository;

        private Movie? _movie;

        public AddShowTimeValidator(IServiceProvider serviceProvider,
            AddShowTimeRequest request) : base(request)
        {
            _hallRepository = serviceProvider.GetRequiredService<IHallRepository>();
            _movieRepository = serviceProvider.GetRequiredService<IMovieRepository>();
            _showTimeRepository = serviceProvider.GetRequiredService<IShowTimeRepository>();
        }

        public override async Task ValidateHall()
        {
            var hall = await _hallRepository.FindAsync(request.HallId);
            if (hall == null)
            {
                errors.Add(new(Code: "showtime-hall", Description: "Phòng chiếu không tồn tại!"));
            }
            else if (hall!.IsDeleted)
            {
                errors.Add(new(Code: "showtime-hall", Description: "Phòng chiếu đã bị xóa!"));
            }
            else if (!hall.IsOpen)
            {
                errors.Add(new(Code: "showtime-hall", Description: "Phòng chiếu đang bảo trì!"));
            }
        }

        public override async Task ValidateMovie()
        {
            _movie = await _movieRepository.FindAsync(request.MovieId);
            if (_movie == null)
            {
                errors.Add(new(Code: "showtime-movie", Description: "Phim không tồn tại!"));
            }
            else if (_movie.IsDeleted)
            {
                errors.Add(new(Code: "showtime-movie", Description: "Phim đã bị xóa!"));
            }
            //else if (!movie.IsOpen)
            //{
            //    errors.Add(new(Code: "showtime-movie", Description: "Phim hiện không mở chiếu!"));
            //}
        }

        public override async Task ValidateTime()
        {
            int duration = _movie is null ? 0 : _movie.Duration;
            var newEndAt = request.BeginAt.AddMinutes(20 + duration);
            // Lấy tất cả các suất chiếu trong cùng phòng (Hall) và không bị hủy hoặc xóa
            var overlappingShowTimes = await _showTimeRepository.GetAllAsync(
                st => st.HallId == request.HallId
                     && !st.IsCanceled
                     && !st.IsDeleted
                     && ((request.BeginAt >= st.BeginAt && request.BeginAt < st.EndAt) ||
                         (newEndAt > st.BeginAt && newEndAt <= st.EndAt) ||
                         (request.BeginAt <= st.BeginAt && newEndAt >= st.EndAt))
                );

            if (overlappingShowTimes.Any())
            {
                errors.Add(new("showtime-overlap", "Bị trùng giờ với suất chiếu khác!"));
            }
        }
    }
}
