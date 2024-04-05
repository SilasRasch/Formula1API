namespace Formula1API.Authentication
{
    public class ApiKeyAuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private string _apiKey;

        public ApiKeyAuthMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(AuthConstants.ApiKeyHeaderName, out var extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("API Key missing");
                return;
            }

            // Portainer / Azure
            var env = Environment.GetEnvironmentVariable(AuthConstants.ApiKeyName)!;

            // Local
            var appsetting = _configuration.GetValue<string>(AuthConstants.ApiKeyName)!;

            // Check if local or environment
            if (env != null)
            {
                _apiKey = env;
            }
            else if (appsetting != null)
            {
                _apiKey = appsetting;
            }
            else
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Api key variable not found");
                return;
            }

            if (!_apiKey.Equals(extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Invalid API Key");
                return;
            }

            await _next(context);
        }
    }
}
