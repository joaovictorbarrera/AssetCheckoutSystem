namespace AssetManagementSystem.Services
{
    public enum ServiceErrorType
    {
        NotFound,
        Forbidden,
        BadRequest
    }

    public class ServiceResult
    {
        public bool Succeeded { get; protected init; }
        public ServiceErrorType? ErrorType { get; protected init; }
        public string? ErrorMessage { get; protected init; }

        protected ServiceResult() { }

        public static ServiceResult Success() =>
            new() { Succeeded = true };

        protected static ServiceResult Fail(ServiceErrorType errorType, string message) =>
            new() { Succeeded = false, ErrorType = errorType, ErrorMessage = message };

        public static ServiceResult NotFound(string message = "Resource not found") =>
            Fail(ServiceErrorType.NotFound, message);

        public static ServiceResult Forbidden(string message) =>
            Fail(ServiceErrorType.Forbidden, message);

        public static ServiceResult BadRequest(string message) =>
            Fail(ServiceErrorType.BadRequest, message);
    }

    public class ServiceResult<T> : ServiceResult
    {
        public T? Value { get; private init; }

        private ServiceResult() { }

        public static ServiceResult<T> Success(T value) =>
            new()
            {
                Succeeded = true,
                Value = value
            };

        private static new ServiceResult<T> Fail(ServiceErrorType errorType, string message) =>
            new()
            {
                Succeeded = false,
                ErrorType = errorType,
                ErrorMessage = message
            };

        public static new ServiceResult<T> NotFound(string message = "Resource not found") =>
            Fail(ServiceErrorType.NotFound, message);

        public static new ServiceResult<T> Forbidden(string message) =>
            Fail(ServiceErrorType.Forbidden, message);

        public static new ServiceResult<T> BadRequest(string message) =>
            Fail(ServiceErrorType.BadRequest, message);
    }
}