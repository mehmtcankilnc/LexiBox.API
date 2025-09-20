using System.Text.Json.Serialization;

namespace LexiBox.API.Entities
{
    public class Result
    {
        protected Result(bool isSuccess, Error error)
        {
            if ((isSuccess && error != Error.None) || (!isSuccess && error == Error.None))
                throw new ArgumentException("Invalid error state.", nameof(error));

            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess { get; }
        [JsonIgnore]
        public bool IsFailure => !IsSuccess;
        [JsonIgnore]
        public Error Error { get; }

        public static Result Success() => new(true, Error.None);
        public static Result Failure(Error error) => new(false, error);

        public static Result<T> Success<T>(T data) => new(data, true, Error.None);
        public static Result<T> Failure<T>(Error error) => new(default!, false, error);
    }

    public sealed class Result<T> : Result
    {
        internal Result(T? data, bool isSuccess, Error error) : base(isSuccess, error)
            => Data = data;

        public T? Data { get; }
    }
}
