namespace ThhTransTracker.Shared.Exceptions
{
    public class UnauthorizedException : BaseException
    {
        public UnauthorizedException() : base(HttpStatusCode.Unauthorized)
        {
        }

        public UnauthorizedException(string message) : base(HttpStatusCode.Unauthorized, message)
        {
        }
    }
}
