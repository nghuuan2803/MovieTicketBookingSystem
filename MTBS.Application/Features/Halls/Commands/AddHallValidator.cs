using MediatR;
using MTBS.Domain.Abstracts.Repositories;
using MTBS.Shared.HallDTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Application.Features.Halls.Commands
{
    public class AddHallValidator : AddHallValidatorBase
    {
        private readonly IHallRepository _repository;
        public AddHallValidator(AddHallRequest request, IHallRepository repository) : base(request)
        {
            _repository = repository;
        }

        protected async override Task ValidateName()
        {
            if (request.Name.Length > 10)
            {
                errors.Add(new Error("rule-hall:", "Tên rạp không được quá 10 ký tự"));
            }

            var hallExists = await _repository.FindAsync(h => h.Name == request.Name && h.CinemaId == request.CinemaId);
            if (hallExists != null)
            {
                errors.Add(new Error("rule-hall:1", "Rạp đã tồn tại tên phòng này!"));
            }
        }

        protected override void ValidateLayout()
        {
            if (string.IsNullOrEmpty(request.Layout) || !IsValidLayout(request.Layout))
            {
                errors.Add(new Error("rule-hall:2", "Sơ đồ ghế không hợp lệ!"));
            }
        }

        protected override void ValidateMetadata()
        {
            var metadata = request.Metadata;
            if (metadata == null)
            {
                errors.Add(new Error("rule-hall-metadata", "Metadata không được bỏ trống!"));
            }
            if (metadata!.Rows <= 0)
            {
                errors.Add(new Error("rule-hall-metadata", "Số hàng phải lớn hơn 0!"));
            }
            if (metadata!.Columns <= 0)
            {
                errors.Add(new Error("rule-hall-metadata", "số cột phải lớn hơn 0!"));
            }
            if (metadata!.Center.Any(p => p < 0))
            {
                errors.Add(new Error("rule-hall-metadata", "Vùng trung tâm không hợp lệ!"));
            }
            if (metadata!.FootPath.Any(p => p < 0 || p > metadata.Columns))
            {
                errors.Add(new Error("rule-hall-metadata", "Lối đi không hợp lệ!"));
            }
        }

        protected override void ValidatePriceCoefficient()
        {
            if (request.PriceCoefficient <= 0 || request.PriceCoefficient > 5)
            {
                errors.Add(new Error("rule-hall-pricecooficient", "Hệ số giá không hợp lệ!"));
            }
        }

        private bool IsValidLayout(string layout)
        {
            try
            {
                var seatMatrix = JsonConvert.DeserializeObject<int[,]>(layout);
                return seatMatrix != null && seatMatrix.Length > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
