using MTBS.Domain.Entities;
using MTBS.Shared.HallDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Application.Features.Halls.Commands
{
    /// <summary>
    /// Use Template method pattern to validate requests
    /// </summary>
    public abstract class AddHallValidatorBase
    {
        protected AddHallRequest request;
        protected List<Error> errors = new();
        protected AddHallValidatorBase(AddHallRequest request)
        {
            this.request = request;
        }

        public async Task<List<Error>> Validate()
        {
            await ValidateName();
            ValidateLayout();
            ValidateMetadata();
            ValidatePriceCoefficient();

            return errors;
        }

        protected abstract Task ValidateName();
        protected abstract void ValidateLayout();
        protected abstract void ValidateMetadata();
        protected abstract void ValidatePriceCoefficient();
    }
}
