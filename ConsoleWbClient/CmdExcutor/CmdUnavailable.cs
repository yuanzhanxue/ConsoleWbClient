/*
 * 由Yuan,Zhanxue创建。
 * 用户： 28850619
 * 日期: 7/19/2013
 * 时间: 2:29 PM
 * 
 */
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleWbClient.CmdExcutor
{
    /// <summary>
    /// Description of CmdUnavailable.
    /// </summary>
    public class CmdUnavailable : AbstractMachineCmd
    {
        public static readonly string CANNOT_EXECUTE = "奴婢做不到啊！";

        protected override string ThreadTag { get { return "CmdUnavailable"; } }

        public CmdUnavailable(string content, bool isContinue, ManualResetEvent exitSignal)
            : base(content, isContinue, exitSignal)
        {
        }

        public override void ExecuteMethod()
        {
        	iMessage.SendComments(WbId, CANNOT_EXECUTE, true);
        }
    }
}
