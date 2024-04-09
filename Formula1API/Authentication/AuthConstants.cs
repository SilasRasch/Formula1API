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
        public const string SimplyConnectionString = "MYSQLCONNSTR_SIMPLY";
        public const string ApiKeyName = "APPSETTING_APIKEY";
        #endregion

        #region Portainer (self-hosted)
        //public const string SimplyConnectionString = "SIMPLY_CONNECTION_STRING";
        //public const string LocalConnectionString = "LOCAL_CONNECTION_STRING";
        //public const string ApiKeyName = "API_KEY";
        #endregion
    }
}
