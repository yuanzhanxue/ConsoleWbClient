/*
 * 由SharpDevelop创建。
 * 用户： 28850619
 * 日期: 7/22/2013
 * 时间: 1:14 PM
 * 
 */
using System;

namespace ConsoleWbClient.CmdExcutor
{
	/// <summary>
	/// Description of ICmdMessagePipe.
	/// </summary>
	public interface ICmdMessagePipe
	{
		void SendComments(string id, string message, bool finished);
	}
}
