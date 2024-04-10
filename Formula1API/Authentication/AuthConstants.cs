namespace Formula1API.Authentication
{
    public static class AuthConstants
    {
        
        
        #region Global
        public const string ApiKeyHeaderName = "X-Api-Key";
        #endregion

        #region Local
        //public const string ApiKeyName = "Authentication:ApiKey";
        //public const string SimplyConnectionString = "Authentication:ConnectionString";
        #endregion

        #region Azure
        //public const string SimplyConnectionString = "MYSQLCONNSTR_SIMPLY";
        //public const string ApiKeyName = "APPSETTING_APIKEY";
        #endregion

        #region Portainer (self-hosted)
        public const string SimplyConnectionString = "SIMPLY_CONNECTION_STRING";
        public const string LocalConnectionString = "LOCAL_CONNECTION_STRING";
        public const string ApiKeyName = "API_KEY";
        #endregion

        public static string GetApiKey(IConfiguration config)
        {
            // Portainer / Azure
            var env = Environment.GetEnvironmentVariable(AuthConstants.ApiKeyName)!;

            // Local
            var appsetting = config.GetValue<string>(AuthConstants.ApiKeyName)!;

            // Check if local or environment
            if (env != null)
            {
                return env;
            }
            else
            {
                return appsetting;
            }
        }

        public static string GetConnectionString(bool useLocal, IConfiguration config)
        {
            // Portainer / Azure
            var env = Environment.GetEnvironmentVariable(AuthConstants.SimplyConnectionString)!; // Simply
            //var env = Environment.GetEnvironmentVariable(AuthConstants.LocalConnectionString!); // Local

            // Local
            var appsetting = config.GetValue<string>(AuthConstants.SimplyConnectionString)!;

            // Check if local or environment
            if (!useLocal)
            {
                if (env != null)
                {
                    return env;
                }
                else
                {
                    return appsetting;
                }
            }
            else
            {
                return Environment.GetEnvironmentVariable(AuthConstants.LocalConnectionString)!;
            }
        }
    }
}
