using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWbClient
{
    class AccountUser
    {
        public static readonly string KEY_ACCOUNT_NAME = "AccountName";
        public static readonly string KEY_PASSWORD = "Password";
        public static readonly string KEY_SCREEN_NAME = "ScreenName";
        public static readonly string KEY_SINCE_ID = "SinceId";

        public static string AccountName
        {
            get { return ConfigurationManager.AppSettings[KEY_ACCOUNT_NAME]; }
        }

        public static string Password
        {
            get { return ConfigurationManager.AppSettings[KEY_PASSWORD]; }
        }

        public static IList<string> ScreenNames
        {
            get { return new List<string>(ConfigurationManager.AppSettings[KEY_SCREEN_NAME].Split(',')); }
        }

        public static string SinceId
        {
            get { return ConfigurationManager.AppSettings[KEY_SINCE_ID]; }
        }
    }
}
