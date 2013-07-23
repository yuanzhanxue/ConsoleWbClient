/*
 * 由Yuan,Zhanxue创建。
 * 用户： 28850619
 * 日期: 7/19/2013
 * 时间: 2:09 PM
 * 
 */
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleWbClient.CmdExcutor
{
    /// <summary>
    /// Description of CmdDownloadFile.
    /// </summary>
    public class CmdDownloadFile : AbstractMachineCmd
    {
        public static readonly string DOWNLOAD_BEGIN = "开始下载，请稍候！";
        public static readonly string DOWNLOADED_FILE = "文件下载已完成！";
        public static readonly string DOWNLOAD_TYPE = "暂不支持HTTP外下载方式。";

        protected override string ThreadTag { get { return "CmdDownloadFile"; } }

        public CmdDownloadFile(string content, bool isContinue, ManualResetEvent exitSignal) : base(content, isContinue, exitSignal) { }

        public override void ExecuteMethod()
        {
            int pos = StrCmd.IndexOf("http");
            if (pos >= 0 && StrCmd.Contains("://"))
            {
                iMessage.SendComments(WbId, DOWNLOAD_BEGIN, false);
                DoDownload(StrCmd.Substring(pos));
            }
            else
            {
                iMessage.SendComments(WbId, DOWNLOAD_TYPE, true);
                return;
            }
            iMessage.SendComments(WbId, DOWNLOADED_FILE, true);
        }

        private bool DoDownload(string link)
        {
            /* https://github.com/yuanzhanxue/ConsoleWbClient/archive/master.zip */
            string origLink = GetFileNameByLink(link);
            string strFileName = origLink.Split('/').Last();

            bool flag = false;
            //打开上次下载的文件
            long pos = 0;
            FileStream fStream;

            if (File.Exists(strFileName))
            {
                fStream = File.OpenWrite(strFileName);
                pos = fStream.Length;
                fStream.Seek(pos, SeekOrigin.Current);
            }
            else
            {
                fStream = new FileStream(strFileName, FileMode.Create);
                pos = 0;
            }

            try
            {
                HttpWebRequest myRequest = (HttpWebRequest)HttpWebRequest.Create(origLink);

                if (pos > 0) myRequest.AddRange((int)pos);  //设置Range值

                //向服务器请求,获得服务器的回应数据流
                Stream myStream = myRequest.GetResponse().GetResponseStream();

                byte[] btContent = new byte[512];
                int intSize = 0;
                intSize = myStream.Read(btContent, 0, 512);

                while (intSize > 0)
                {
                    fStream.Write(btContent, 0, intSize);
                    intSize = myStream.Read(btContent, 0, 512);
                }

                fStream.Close();
                myStream.Close();
                flag = true;
            }
            catch (Exception)
            {
                fStream.Close();
                flag = false;       //返回false下载失败
            }

            return flag;
        }

        private string GetFileNameByLink(string link)
        {
            using (WebClient client = new MyWebClient())
            {
                client.Headers.Add("Referer", link);
                Stream stream = null;
                try
                {
                    stream = client.OpenRead(link);
                    return client.ResponseHeaders["Location"];
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (stream != null) stream.Close();
                }
            }
        }

        internal class MyWebClient : WebClient
        {
            /// <summary>
            /// 重写获取WebRequest的方法
            /// </summary>
            /// <param name="address"></param>
            /// <returns></returns>
            protected override WebRequest GetWebRequest(Uri address)
            {
                HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(address);
                request.AllowAutoRedirect = false;
                return request;
            }
        }
    }
}
