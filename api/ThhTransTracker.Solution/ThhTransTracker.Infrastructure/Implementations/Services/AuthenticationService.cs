namespace ThhTransTracker.Infrastructure.Implementations.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<AuthenticationService> _logger;
        private readonly IOptions<AppSettings> _appSettings;

        public AuthenticationService(IHttpClientFactory httpClientFactory, ILogger<AuthenticationService> logger, IOptions<AppSettings> appSettings)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _appSettings = appSettings;
        }

        public async Task<string> AuthenticateAsync(LoginDto loginDto)
        {
            _logger.LogInformation($"Trying to Authenticate {loginDto}");
            var client = _httpClientFactory.CreateClient("TheHaulageHub");

            string payload = JsonConvert.SerializeObject(new {username = loginDto.Email, password = loginDto.Password});

            var response = await client.PostAsync(_appSettings.Value.TheHaulageHubAuthenticate, new StringContent(payload, Encoding.UTF8, "application/json"));

            string res = await response.Content.ReadAsStringAsync();

            var resultObj = JsonConvert.DeserializeObject<AuthenticateResponseDto>(res);

            string result = resultObj.Token;

            if (string.IsNullOrEmpty(result))
            {
                _logger.LogError($"Login failed - {res}");
                throw new ServiceUnavailableException("Authentication service failed");
            }

            return result;
        }
    }
}
