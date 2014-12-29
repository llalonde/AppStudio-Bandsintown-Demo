using System.Collections.Generic;

namespace AppStudio.Data
{
    public static class OAuthTokensRepository
    {
        private static Dictionary<long, OAuthTokens> Tokens { get; set; }

        static OAuthTokensRepository()
        {
            Tokens = new Dictionary<long, OAuthTokens>();


            Tokens.Add(92, new OAuthTokens
                            {
                                { "ConsumerKey", "[YOUR CONSUMER KEY]" },
                                { "ConsumerSecret", "[YOUR CONSUMER SECRET]" },
                                { "AccessToken", "[YOUR ACCESS TOKEN]" },
                                { "AccessTokenSecret", "[YOUR ACCESS TOKEN SECRET]" }
                            });

        }

        public static OAuthTokens GetTokens(long key)
        {
            if (Tokens.ContainsKey(key))
            {
                return Tokens[key];
            }
            return null;
        }

    }
}
