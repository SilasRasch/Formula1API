namespace Formula1API.Authentication
{
    public class ApiKeyAuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

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

            //var apiKey = Environment.GetEnvironmentVariable(AuthConstants.AzureApiKeyName);
            var apiKey = _configuration.GetValue<string>("API_KEY");
            //var apiKey = _configuration.GetValue<string>(AuthConstants.ApiKeySectionName);

            if (apiKey != null)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Api key variable not found");
                return;
            }

            if (!apiKey.Equals(extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Invalid API Key");
                return;
            }

            await _next(context);
        }
    }
}
