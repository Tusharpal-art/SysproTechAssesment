namespace SysproTech.App.Res
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string? ErrorMessage { get; set; }
        public int StatusCode { get; set; }

        public static Result<T> Successs(T data)
        {
            return new Result<T>
            {
                Success = true,
                Data = data,
                StatusCode = 200
            };
        }

        public static Result<T> Failure(string error)
        {
            return new Result<T>
            {
                Success = false,
                ErrorMessage = error,
                StatusCode = 400
            };
        }
    }
}
