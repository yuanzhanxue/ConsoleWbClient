/*
 * 由Yuan,Zhanxue创建。
 * 用户： 28850619
 * 日期: 7/19/2013
 * 时间: 1:57 PM
 * 
 */
using System;
using System.Threading;
using ConsoleWbClient.Utilities;

namespace ConsoleWbClient.CmdExcutor
{
    /// <summary>
    /// Description of AbstractMachineCmd.
    /// </summary>
    public abstract class AbstractMachineCmd
    {        
        /// <summary>
        /// 线程循环退出标志
        /// </summary>
        public bool IsContinue { get; set; }

        /// <summary>
        /// 当前线程标识
        /// </summary>
        protected abstract string ThreadTag { get; }
        
        /// <summary>
        /// 线程退出时向主线程发出信号
        /// </summary>
        private ManualResetEvent ExitSignal { get; set; }
        
    	/// <summary>
        /// 消息传递接口
        /// </summary>
        protected ICmdMessagePipe iMessage = CmdEventMessage.GetInstance();
        
        /// <summary>
        /// 微博指令内容
        /// </summary>
        protected string StrCmd { get; set; }
        
        /// <summary>
        /// 微博ID
        /// </summary>
        protected string WbId { get; set;}

        public AbstractMachineCmd(string content, bool isContinue, ManualResetEvent exitSignal)
        {
            StrCmd = content;
            IsContinue = isContinue;
            ExitSignal = exitSignal;
        }
        
        /// <summary>
        /// 实现类
        /// </summary>
        public abstract void ExecuteMethod();
        
        /// <summary>
        /// 执行代码
        /// </summary>
        public virtual void Execute(string wbId)
        {  
        	Thread thread = new Thread(new ThreadStart(DoWork));
            thread.IsBackground = true;
            WbId = wbId;
            thread.Start();
            Log.I(string.Format("启用子线程{0}", ThreadTag));
        }
        
        private void DoWork()
        {
            try
            {
                if (WbId != null)
                {
                    ExecuteMethod();
                    Log.I(string.Format("子线程{0}处理完当前数据行", ThreadTag));
                }
            }
            catch (Exception ex)
            {
                Log.E(string.Format("子线程{0}处理出错:{1}", ThreadTag, ex.ToString()));
            }

            Log.I(string.Format("子线程{0} 退出", ThreadTag));
            ExitSignal.Set();//告诉主线程，我已退出线程
        }
    }
}
