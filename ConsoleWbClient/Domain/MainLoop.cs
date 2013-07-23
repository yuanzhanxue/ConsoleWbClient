/*
 * 由SharpDevelop创建。
 * 用户： 28850619
 * 日期: 7/22/2013
 * 时间: 1:53 PM
 * 
 */
using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;

using NetDimension.Weibo;

using ConsoleWbClient.Utilities;
using ConsoleWbClient.CmdExcutor;


namespace ConsoleWbClient.Domain
{
    /// <summary>
    /// Description of MainLoop.
    /// </summary>
    public class MainLoop
    {
        private static readonly int LOOP_WAIT = 1000 * 20;
        private static readonly int WAIT_FOR_SUBTREAD = 1000 * 60;

        private Client sina = Login.getSina();

        Dictionary<string, ManualResetEvent> eventHanles = new Dictionary<string, ManualResetEvent>();

        public MainLoop()
        {
            CmdEventMessage.GetInstance().MsgEvent += new CmdEventMessage.MsgEventHandler(CommitComment);
        }

        private void CommitComment(string id, string comment, bool finished)
        {
            if (finished && eventHanles.ContainsKey(id))
            {
                eventHanles.Remove(id);
            }

            if (sina != null)
            {
                sina.API.Entity.Comments.Create(id, comment);
            }
        }

        public void Excute()
        {
            while (SystemParamSet.IsEnableThread == 1)
            {
                Log.I("New loop start.");
                if (sina == null)
                {
                    Log.E("微博帐号登录失败！");
                    return;
                }

                var uid = sina.API.Entity.Account.GetUID();
                var msgs = sina.API.Entity.Account.UnreadCount(uid);
                int mentionCount = 0;

                if (int.TryParse(msgs.MentionStatus, out mentionCount) && mentionCount > 0)
                {
                    Log.I("SinceId:" + SystemParamSet.SinceId);
                    var metions = sina.API.Entity.Statuses.Mentions(
                        sinceID: SystemParamSet.SinceId
                        , count: mentionCount
                        , filterByAuthor: 1
                        , filterBySource: 0
                        , filterByType: 1);

                    foreach (var item in metions.Statuses)
                    {
                        if (SystemParamSet.ScreenNames.Contains(item.User.ScreenName))
                        {
                            ManualResetEvent eventSignal = new ManualResetEvent(false);
                            if (eventHanles.ContainsKey(item.ID))
                            {
                                eventHanles[item.ID] = eventSignal;
                            }
                            else
                            {
                                eventHanles.Add(item.ID, eventSignal);
                            }

                            CmdFactory factory = new CmdFactory(item.Text);
                            factory.GetCommander(true, eventSignal).Execute(item.ID);
                        }

                        SystemParamSet.SinceId = item.ID;
                    }
                }

                System.Threading.Thread.Sleep(LOOP_WAIT);
            }

            EventWaitHandle.WaitAll(eventHanles.Values.ToArray(), WAIT_FOR_SUBTREAD);
        }
    }
}
