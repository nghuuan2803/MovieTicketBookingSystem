using MTBS.Shared.ShowTimeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Application.Features.ShowTimes.Commands
{
    public abstract class AddShowTimeValidatorBase
    {
        protected AddShowTimeRequest request;
        protected List<Error> errors = new();

        protected AddShowTimeValidatorBase(AddShowTimeRequest request)
        {
            this.request = request;
        }

        public async Task<List<Error>> Validate()
        {
            await ValidateHall();
            await ValidateMovie();
            await ValidateTime();      
            return errors;
        }

        public abstract Task ValidateHall();
        public abstract Task ValidateMovie();
        public abstract Task ValidateTime();
    }
}
