using AutoMapper;
using MediatR;
using MTBS.Application.Helper;
using MTBS.Domain.Abstracts;
using MTBS.Domain.Abstracts.Repositories;
using MTBS.Domain.Entities;
using MTBS.Domain.SampleModels;
using MTBS.Domain.Values;
using MTBS.Shared.HallDTOs;
using MTBS.Shared.SimpleDTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Application.Features.Halls.Commands
{
    public class AddHallCommandHandler : IRequestHandler<AddHallCommand, Result<Hall>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHallRepository _repository;
        private readonly IMapper _mapper;
        private List<Error>? errors;

        public AddHallCommandHandler(IHallRepository repository,
            IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Result<Hall>> Handle(AddHallCommand command,
            CancellationToken cancellationToken)
        {
            var validator = new AddHallValidator(command.Request, _repository);
            errors = await validator.Validate();

            if (errors.Count > 0)
            {
                return Result<Hall>.Failure(errors);
            }

            var hall = _mapper.Map<Hall>(command.Request);
            hall.CreatedAt = DateTime.Now;
            hall.CreatedBy = command.Sender;
            hall.Metadata = JsonConvert.SerializeObject(command.Request.Metadata);
            hall.Seats = GenerateSeats(command.Request.Layout, command.Sender);

            await _repository.AddAsync(hall);
            await _unitOfWork.BeginAsync();
            try
            {
                await _unitOfWork.CommitAsync();
                return Result<Hall>.Success(hall);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollBackAsync();
                return Result<Hall>.Failure(new List<Error> { new Error("db-error", ex.Message) });
            }
        }

        private ICollection<Seat> GenerateSeats(string layout, string? sender)
        {
            int[,] seatMatrix = JsonConvert.DeserializeObject<int[,]>(layout)!;
            if (seatMatrix == null || seatMatrix.Length == 0)
                throw new Exception("Không có ghế");
            // Tạo danh sách ghế
            var seats = new List<Seat>();
            for (int row = 0; row < seatMatrix.GetLength(0); row++)
            {
                int colName = seatMatrix.GetLength(1) - CountZero(seatMatrix, row);
                // Xác định tên hàng (A, B, C,...)
                var rowName = (char)('A' + row);

                // Lặp qua các cột và đảo ngược thứ tự ghế
                for (int col = 0; col < seatMatrix.GetLength(1); col++)
                {
                    var seatType = seatMatrix[row, col];

                    // Bỏ qua nếu là ghế trống (loại 0)
                    if (seatType == 0) continue;

                    // Tạo tên ghế theo thứ tự ngược
                    seats.Add(new Seat
                    {
                        CreatedAt = DateTime.Now,
                        CreatedBy = sender,
                        Name = $"{rowName}{colName--}", // Đảo ngược thứ tự tên ghế
                        Type = seatType switch
                        {
                            1 => SeatType.Single,
                            2 => SeatType.Couple,
                            _ => SeatType.VIP,
                        },
                        PriceCoefficient = seatType switch
                        {
                            1 => 1.0,
                            2 => 1.8,
                            _ => 1.5,
                        },
                        HallId = 0,
                        Row = row,
                        Colums = col,
                    });
                }
            }
            return seats;
        }
        private int CountZero(int[,] arr, int row)
        {
            int count = 0;
            for (int i = 0; i < arr.GetLength(1); i++)
            {
                if (arr[row, i] == 0) count++;
            }
            return count;
        }
    }
}
