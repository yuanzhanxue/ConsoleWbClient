/*
 * 由Yuan,Zhanxue创建。
 * 用户： 28850619
 * 日期: 7/19/2013
 * 时间: 2:09 PM
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace ConsoleWbClient.CmdExcutor
{
	/// <summary>
	/// Description of CmdDownloadFile.
	/// </summary>
	public class CmdDownloadFile: AbstractMachineCmd
	{
		public static readonly string DOWNLOAD_BEGIN = "开始下载，请稍候！";
		public CmdDownloadFile(string content):base(content){}
		
		public override bool ExecuteCmd(out string ret)
		{
			ret = DOWNLOAD_BEGIN;
			return true;
		}
	}
}
