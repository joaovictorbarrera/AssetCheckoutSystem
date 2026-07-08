namespace AssetCheckoutSystem.Services
{
    public enum ServiceErrorType
    {
        ResourceNotFound,
        AccessDenied,
        InvalidOperation,
        Unauthorized
    }

    public class ServiceResult
    {
        public bool Succeeded { get; protected init; }
        public ServiceErrorType? ErrorType { get; protected init; }
        public string? ErrorMessage { get; protected init; }

        protected ServiceResult() { }

        public static ServiceResult Success() =>
            new() { Succeeded = true };

        protected static ServiceResult Fail(ServiceErrorType errorType, string? message) =>
            new() { Succeeded = false, ErrorType = errorType, ErrorMessage = message };

        public static ServiceResult ResourceNotFound() =>
            Fail(ServiceErrorType.ResourceNotFound, null);

        public static ServiceResult AccessDenied(string message) =>
            Fail(ServiceErrorType.AccessDenied, message);

        public static ServiceResult InvalidOperation(string message) =>
            Fail(ServiceErrorType.InvalidOperation, message);

        public static ServiceResult Unauthorized() =>
            Fail(ServiceErrorType.Unauthorized, null);
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

        private static new ServiceResult<T> Fail(
            ServiceErrorType errorType, 
            string? message) => new()
                {
                    Succeeded = false,
                    ErrorType = errorType,
                    ErrorMessage = message
                };

        public static new ServiceResult<T> ResourceNotFound() =>
            Fail(ServiceErrorType.ResourceNotFound, null);

        public static new ServiceResult<T> AccessDenied(string message) =>
            Fail(ServiceErrorType.AccessDenied, message);

        public static new ServiceResult<T> InvalidOperation(string message) =>
            Fail(ServiceErrorType.InvalidOperation, message);
        public static new ServiceResult<T> Unauthorized() =>
            Fail(ServiceErrorType.Unauthorized, null);
    }
}