/*
 * 由Yuan,Zhanxue创建。
 * 用户： 28850619
 * 日期: 7/19/2013
 * 时间: 2:29 PM
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace ConsoleWbClient.CmdExcutor
{
	/// <summary>
	/// Description of CmdUnavailable.
	/// </summary>
	public class CmdUnavailable: AbstractMachineCmd
	{
		public static readonly string CANNOT_EXECUTE = "奴婢做不到啊！";
        public static readonly string ILLEGAL_USER_CMD = "你谁啊，不好使！";
		public CmdUnavailable(string content):base(content)
		{
		}
		
		public override bool ExecuteCmd(out string ret)
		{
			ret = CANNOT_EXECUTE;
			return true;
		}
	}
}
