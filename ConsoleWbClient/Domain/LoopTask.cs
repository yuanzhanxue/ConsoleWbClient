using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConsoleWbClient.CmdExcutor;
using ConsoleWbClient.Utilities;
using NetDimension.Weibo.Interface.Entity;

namespace ConsoleWbClient.Domain
{
    class LoopTask
    {
        private static readonly int LOOP_WAIT = 1000 * 20;
        private Thread mThread;

        private LoopTask() { }
        public static readonly LoopTask Instance = new LoopTask();

        public void Start()
        {
            mThread = new Thread(new ThreadStart(DoLoopTask));
            mThread.Start();
        }

        public void Stop()
        {
            if (mThread.IsAlive) mThread.Abort();
        }

        private async void DoLoopTask()
        {
            while (true)
            {
                Log.I("New loop start.");
                var sina = Login.getSina();
                var uid = sina.API.Entity.Account.GetUID();
                var msgs = sina.API.Entity.Account.UnreadCount(uid);
                int mentionCount = 0;

                if (int.TryParse(msgs.MentionStatus, out mentionCount) && mentionCount > 0)
                {
                    Log.I("AccountUser.SinceId:" + AccountUser.SinceId);
                    var metions = sina.API.Entity.Statuses.Mentions(
                        sinceID: AccountUser.SinceId
                        , count: mentionCount
                        , filterByAuthor: 1
                        , filterBySource: 0
                        , filterByType: 1);

                    foreach (var item in metions.Statuses)
                    {
                        if (AccountUser.ScreenNames.Contains(item.User.ScreenName))
                        {
                            CmdFactory factory = new CmdFactory(item.Text);
                            AbstractMachineCmd cmder = factory.GetCommander();
                            CommentInterface comments = sina.API.Entity.Comments;
                            comments.Create(item.ID, cmder.PreExcute());
                            string comment = await cmder.ExecuteCmd();
                            if (comment != string.Empty) comments.Create(item.ID, comment);
                        }

                        UpdateSinceId(item.ID);
                    }
                }

                System.Threading.Thread.Sleep(LOOP_WAIT);
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
