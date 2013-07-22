/*
 * 由SharpDevelop创建。
 * 用户： 28850619
 * 日期: 7/22/2013
 * 时间: 1:28 PM
 * 
 */
using System;

using ConsoleWbClient.Utilities;

namespace ConsoleWbClient.Domain
{
	/// <summary>
    /// 线程上下文
    /// </summary>
    public abstract class AbsThreadContext
    {
        public  AbsThreadContext()
        {

        }

        /// <summary>
        /// 开始
        /// </summary>
        public abstract void Start();
        /// <summary>
        /// 终止
        /// </summary>
        public abstract void Abort();


        /// <summary>
        /// 向订阅者发布线程启动成功信息
        /// </summary>
        /// <param name="str"></param>
        public void RaiseStartSuccessEvent(string str)
        {
        	Log.I(str);
        }

        /// <summary>
        /// 向订阅者发布线程停止成功信息
        /// </summary>
        /// <param name="str"></param>
        public void RaiseAbortSuccessEvent(string str)
        {
            Log.I(str);
        }


        /// <summary>
        /// 向订阅者发布线程启动失败信息
        /// </summary>
        /// <param name="str"></param>
        public void RaiseStartFailedEvent(string str)
        {
        	Log.E(str);
        }

        /// <summary>
        /// 向订阅者发布线程停止失败信息
        /// </summary>
        /// <param name="str"></param>
        public void RaiseAbortFailedEvent(string str)
        {
            Log.E(str);
        }
    }
}
