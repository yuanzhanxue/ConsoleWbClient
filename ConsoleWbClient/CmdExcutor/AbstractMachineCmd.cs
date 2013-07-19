/*
 * 由Yuan,Zhanxue创建。
 * 用户： 28850619
 * 日期: 7/19/2013
 * 时间: 1:57 PM
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace ConsoleWbClient.CmdExcutor
{
	/// <summary>
	/// Description of AbstractMachineCmd.
	/// </summary>
	public abstract class AbstractMachineCmd
	{
		protected string strCmd{get; set;}
		
		public AbstractMachineCmd(string content)
		{
			strCmd = content;
		}
		
		public abstract bool ExecuteCmd(out string ret);
	}
}
