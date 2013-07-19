﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetDimension.Json;
using ConsoleWbClient.CmdExcutor;

namespace ConsoleWbClient
{
    class Program
    {
        static void Main(string[] args)
        {
            int wait = 1000 * 20;

            while (true)
            {
                Console.WriteLine("hello");

                var sina = Login.getSina();
                var uid = sina.API.Entity.Account.GetUID();
                var msgs = sina.API.Entity.Account.UnreadCount(uid);

                int mentionCount = 0;
                if (int.TryParse(msgs.MentionStatus, out mentionCount) && mentionCount > 0)
                {
                    Console.WriteLine("AccountUser.SinceId:" + AccountUser.SinceId);
                    var metions = sina.API.Entity.Statuses.Mentions(
                    	sinceID: AccountUser.SinceId
                        , count: mentionCount
                        , filterByAuthor: 1
                        , filterBySource: 0
                        , filterByType: 1);

                    foreach (var item in metions.Statuses)
                    {
						if(AccountUser.ScreenNames.Contains(item.User.ScreenName))
						{
							CmdFactory factory = new CmdFactory(item.Text);
							string retStr = string.Empty;
							if(factory.GetCommander().ExecuteCmd(out retStr))
							{
								sina.API.Entity.Comments.Create(item.ID,retStr);
							}
						}

						UpdateSinceId(item.ID);
                    }
                }

                System.Threading.Thread.Sleep(wait);
            }
        }

        private static void UpdateSinceId(string id = "0")
        {
            if (id.CompareTo(AccountUser.SinceId) > 0)
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings.Remove(AccountUser.KEY_SINCE_ID);
                config.AppSettings.Settings.Add(AccountUser.KEY_SINCE_ID, id);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }
    }
}
