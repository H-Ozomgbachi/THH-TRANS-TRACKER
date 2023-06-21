namespace ThhTransTracker.API.Controllers.v1
{
    public class AuthenticationController : BaseControllerV1
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult> AuthenticateAsync([FromForm]LoginDto loginDto)
        {
            var response = await _authenticationService.AuthenticateAsync(loginDto);
            return Ok(new {token = response});
        }
    }
}
