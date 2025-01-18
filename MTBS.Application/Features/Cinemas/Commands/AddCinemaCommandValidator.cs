using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Application.Features.Cinemas.Commands
{
    public class AddCinemaCommandValidator : AbstractValidator<AddCinemaCommand>
    {
        public AddCinemaCommandValidator()
        {
            RuleFor(p => p.UserName).NotEmpty().WithMessage("Lỗi Xác thực: UserName bỏ trống!");
            RuleFor(p => p.Request.Name).NotEmpty().WithMessage("Tên rạp không được bỏ trống!");
        }
    }
}
