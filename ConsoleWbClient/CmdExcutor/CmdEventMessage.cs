/*
 * 由SharpDevelop创建。
 * 用户： 28850619
 * 日期: 7/22/2013
 * 时间: 1:18 PM
 * 
 */
using System;

namespace ConsoleWbClient.CmdExcutor
{
	/// <summary>
	/// Description of CmdEventMessage.
	/// </summary>
	public class CmdEventMessage: ICmdMessagePipe
	{
		public delegate void MsgEventHandler(string id, string msg, bool finished);
		public event MsgEventHandler MsgEvent;
		private static CmdEventMessage instance = null;
        private static object lockOjb = new object();
        
        private CmdEventMessage(){ }

        /// <summary>
        /// 获取一个事件消息传递对象，本类单例模式
        /// </summary>
        /// <returns></returns>
        public static CmdEventMessage GetInstance()
        {
            if (instance == null)
            {
                lock (lockOjb)
                {
                    if (instance == null)
                    {
                        instance = new CmdEventMessage();
                    }
                }
            }

            return instance;
        }
		
		public void SendComments(string id, string message, bool finished)
        {
            if (MsgEvent != null)
                MsgEvent(id, message, finished);
        }
	}
}
