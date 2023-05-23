namespace ThhTransTracker.Shared.Types
{
    public class Result<T>
    {
        public T Content { get; set; }
        public Error Error { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        public bool HasError => ErrorMessage != string.Empty;
        public bool IsSuccess { get; set; } = true;
    }
}
