namespace ThhTransTracker.API.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class BaseControllerV1 : ControllerBase
    {
        protected void ValidateEmployeeUniqueCode(string userId, string uniqueCode)
        {
            if (userId != uniqueCode)
            {
                throw new UnauthorizedException("You are not authorized");
            }
        }
    }
}
