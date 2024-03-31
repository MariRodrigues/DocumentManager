namespace DocumentManagerApi.Shared
{
    public class ResponseApi<T>
    {
        public T Result { get; set; }
        public int Id { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }

        public ResponseApi(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public ResponseApi(bool success, T result)
        {
            Success = success;
            Result = result;
        }
    }
}
