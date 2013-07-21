/*
 * 由SharpDevelop创建。
 * 用户： 28850619
 * 日期: 7/19/2013
 * 时间: 4:24 PM
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Threading.Tasks;

namespace ConsoleWbClient.CmdExcutor
{
    /// <summary>
    /// Description of CmdTakePhoto.
    /// </summary>
    public class CmdTakePhoto : AbstractMachineCmd
    {
        public static readonly string TAKING_PHOTO = "正在拍照，瞧好吧，您呐！";
        public static readonly string TAKED_PHOTO = "拍完了，快来看！";
        public CmdTakePhoto(string content)
            : base(content)
        {
        }

        public override string PreExcute()
        {
            return TAKING_PHOTO;
        }

        public override async Task<string> ExecuteCmd()
        {
            return await Task.Run(() => { return TAKED_PHOTO; });
        }
    }
}
