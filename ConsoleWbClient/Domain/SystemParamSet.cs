/*
 * 由SharpDevelop创建。
 * 用户： 28850619
 * 日期: 7/22/2013
 * 时间: 2:02 PM
 * 
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ConsoleWbClient.Domain
{
    /// <summary>
    /// 系统公共参数设置类,静态使用，不能用new构造
    /// </summary>
    public static class SystemParamSet
    {
        private static readonly string KEY_ENABLE_THREAD = "IsEnableThread";
        private static readonly string KEY_ACCOUNT_NAME = "AccountName";
        private static readonly string KEY_PASSWORD = "Password";
        private static readonly string KEY_SCREEN_NAME = "ScreenName";
        private static readonly string KEY_SINCE_ID = "SinceId";
        private static readonly string KEY_DOWNLOADS = "FilePath";
        private static readonly string KEY_PHOTOS = "PhotoPath";
        /// <summary>
        /// 构造加载
        /// </summary>
        static SystemParamSet()
        {
            isEnableThread = int.Parse(ConfigurationManager.AppSettings[KEY_ENABLE_THREAD]);
            accountName = ConfigurationManager.AppSettings[KEY_ACCOUNT_NAME];
            password = ConfigurationManager.AppSettings[KEY_PASSWORD];
            screenNames = ConfigurationManager.AppSettings[KEY_SCREEN_NAME];
            sinceId = ConfigurationManager.AppSettings[KEY_SINCE_ID];
            dowloads = ConfigurationManager.AppSettings[KEY_DOWNLOADS];
            photos = ConfigurationManager.AppSettings[KEY_PHOTOS];
        }

        /// <summary>
        /// 持久到文件
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        private static void SetField(string field, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove(field);
            config.AppSettings.Settings.Add(field, value);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private static volatile int isEnableThread = 0;
        /// <summary>
        /// 是否启用线程，1:启用 0:禁止
        /// </summary>
        public static int IsEnableThread
        {
            get { return SystemParamSet.isEnableThread; }
            set
            {
                SystemParamSet.isEnableThread = value;
                SetField(KEY_ENABLE_THREAD, value.ToString());
            }
        }

        private static volatile string accountName = string.Empty;
        public static string AccountName
        {
            get { return SystemParamSet.accountName; }
            set
            {
                SystemParamSet.accountName = value;
                SetField(KEY_ACCOUNT_NAME, value);
            }
        }

        private static volatile string password = string.Empty;
        public static string Password
        {
            get { return SystemParamSet.password; }
            set
            {
                SystemParamSet.password = value;
                SetField(KEY_PASSWORD, value);
            }
        }

        private static volatile string screenNames = string.Empty;
        public static IList<string> ScreenNames
        {
            get { return new List<string>(SystemParamSet.screenNames.Split(',')); }
            set
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < value.Count; i++)
                {
                    sb.Append(value[i]);
                    if (i < value.Count - 1) sb.Append(',');
                }
                SystemParamSet.screenNames = sb.ToString();
                SetField(KEY_SCREEN_NAME, sb.ToString());
            }
        }

        private static volatile string sinceId = string.Empty;
        public static string SinceId
        {
            get { return SystemParamSet.sinceId; }
            set
            {
                SystemParamSet.sinceId = value;
                SetField(KEY_SINCE_ID, value);
            }
        }

        private static volatile string dowloads = string.Empty;
        public static string DownloadPath
        {
            get { return SystemParamSet.dowloads; }
            set
            {
                SystemParamSet.dowloads = value;
                SetField(KEY_DOWNLOADS, value);
            }
        }
        
        private static volatile string photos = string.Empty;
        public static string PhotoPath
        {
            get { return SystemParamSet.photos; }
            set
            {
                SystemParamSet.photos = value;
                SetField(KEY_PHOTOS, value);
            }
        }
    }
}
