using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Application
{
    public class Result
    {
        public Error Error { get; set; }
        public bool IsSuccess { get; set; } = true;
        public bool IsFailure => !IsSuccess;

        protected Result(bool isSuccess, Error error)
        {
            if (isSuccess && error != Error.None ||
                !isSuccess && error == Error.None)
            {
                throw new ArgumentException("Invalid error", nameof(error));
            }

            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success() => new(true, Error.None);

        public static Result Failure(Error error) => new(false, error);
    }

    public sealed class Result<T> : Result where T : class
    {
        public T Data { get; set; }

        private Result(T data, bool isSuccess, Error error) : base(isSuccess, error)
        {
            Data = data;
        }
        public static Result<T> Success(T data) => new(data, true, Error.None);

        public static Result<T> Failure(Error error) => new (null!, false, error);
    }
}
