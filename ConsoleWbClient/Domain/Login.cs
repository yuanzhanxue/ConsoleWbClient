using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetDimension.Weibo;

namespace ConsoleWbClient.Domain
{
    static class Login
    {
        static readonly string APP_KEY = "137994211";
        static readonly string APP_SECRET = "423dc5efdd8134c5d85abdc5be290455";
        static readonly string CALLBACK_ADDRESS = @"https://api.weibo.com/oauth2/default.html";

        static string accessToken = null;
        static OAuth Oauth { get; set; }

        public static Client getSina()
        {
            if (accessToken != null)
            {
                Oauth = new OAuth(APP_KEY, APP_SECRET, accessToken, null);
            }

            if (Oauth == null || Oauth.VerifierAccessToken() != TokenResult.Success)
            {
                Oauth = new OAuth(APP_KEY, APP_SECRET, CALLBACK_ADDRESS);
            }

            bool result = Oauth.ClientLogin(SystemParamSet.AccountName, SystemParamSet.Password);
            if (result)
            {
                accessToken = Oauth.AccessToken;
                return new Client(Oauth);
            }

            return null;
        }
    }
}