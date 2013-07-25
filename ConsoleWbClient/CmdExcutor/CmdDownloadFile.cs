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
using ConsoleWbClient.Domain;

namespace ConsoleWbClient.CmdExcutor
{
    /// <summary>
    /// Description of CmdDownloadFile.
    /// </summary>
    public class CmdDownloadFile : AbstractMachineCmd
    {
        private static readonly string DOWNLOAD_BEGIN = "开始下载，请稍候！";
        private static readonly string DOWNLOADED_FILE_SUCCESS = "文件下载已完成！";
        private static readonly string DOWNLOADED_FILE_FAILED = "主人，对不起，文件下载失败了！";
        private static readonly string DOWNLOAD_TYPE = "仅支持HTTP,FTP下载方式。";

        protected override string ThreadTag { get { return "CmdDownloadFile"; } }

        public CmdDownloadFile(string content, bool isContinue, ManualResetEvent exitSignal) : base(content, isContinue, exitSignal) { }

        public override void ExecuteMethod()
        {
            string finalMsg = DOWNLOADED_FILE_SUCCESS;
            AbsDownloader downloader = null;

            if (HttpDownloader.IsLegalAddress(StrCmd))
            {
                downloader = new HttpDownloader(StrCmd);
            }
            else if (FtpDownloader.IsLegalAddress(StrCmd))
            {
                downloader = new FtpDownloader(StrCmd);
            }
            else
            {
                downloader = null;
            }

            if (downloader != null)
            {
                iMessage.SendComments(WbId, DOWNLOAD_BEGIN, false);
                finalMsg = downloader.DoDownload() ? DOWNLOADED_FILE_SUCCESS : DOWNLOADED_FILE_FAILED;
            }
            else
            {
                iMessage.SendComments(WbId, DOWNLOAD_TYPE, true);
                return;
            }

            iMessage.SendComments(WbId, finalMsg, true);
        }

        internal abstract class AbsDownloader
        {
            protected DirectoryInfo FilePath { get; private set; }

            public AbsDownloader(string strCmd)
            {
                if (File.Exists(SystemParamSet.DownloadPath))
                {
                    FilePath = new DirectoryInfo(SystemParamSet.DownloadPath);
                }
                else
                {
                    FilePath = Directory.CreateDirectory(SystemParamSet.DownloadPath);
                }
            }

            protected string UriLink { get; set; }

            public abstract bool DoDownload();
        }

        /// <summary>
        /// Download file by HTTP
        /// </summary>
        internal class HttpDownloader : AbsDownloader
        {
            private static readonly string PREFIX = "http://";

            public HttpDownloader(string strCmd)
                : base(strCmd)
            {
                UriLink = GetOrignalLink(strCmd.Substring(strCmd.IndexOf(PREFIX)));
            }

            public static bool IsLegalAddress(string strCmd)
            {
                return strCmd.Contains(PREFIX);
            }

            public override bool DoDownload()
            {
                string targetFile = UriLink.Split('/').Last();
                targetFile = Path.Combine(FilePath.FullName, targetFile);
                bool flag = false;
                // 打开上次下载的文件
                long pos = 0;
                FileStream fStream;

                if (File.Exists(targetFile))
                {
                    fStream = File.OpenWrite(targetFile);
                    pos = fStream.Length;
                    fStream.Seek(pos, SeekOrigin.Current);
                }
                else
                {
                    fStream = new FileStream(targetFile, FileMode.Create);
                    pos = 0;
                }

                try
                {
                    HttpWebRequest myRequest = (HttpWebRequest)HttpWebRequest.Create(UriLink);

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

            private string GetOrignalLink(string link)
            {
                /* https://github.com/yuanzhanxue/ConsoleWbClient/archive/master.zip */
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
                protected override WebRequest GetWebRequest(Uri address)
                {
                    HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(address);
                    request.AllowAutoRedirect = false;
                    return request;
                }
            }
        }

        /// <summary>
        /// Download file by FTP
        /// </summary>
        internal class FtpDownloader : AbsDownloader
        {
            private static readonly string PREFIX = "ftp://";

            public FtpDownloader(string strCmd)
                : base(strCmd)
            {
                UriLink = PREFIX + strCmd.Substring(strCmd.IndexOf("://") + 3);
            }

            public static bool IsLegalAddress(string strCmd)
            {
                return strCmd.ToLower().Contains(PREFIX);
            }

            public override bool DoDownload()
            {
                string targetFile = UriLink.Split('/').Last();
                targetFile = Path.Combine(FilePath.FullName, targetFile);

                if (File.Exists(targetFile))
                {
                    File.Delete(targetFile);
                }

                FileStream fStream = new FileStream(targetFile, FileMode.Create);

                try
                {
                    FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(UriLink));
                    reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                    reqFTP.UseBinary = true;
                    reqFTP.KeepAlive = false;

                    FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                    Stream ftpStream = response.GetResponseStream();
                    long cl = response.ContentLength;
                    int bufferSize = 2048;
                    int readCount;
                    byte[] buffer = new byte[bufferSize];

                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                    while (readCount > 0)
                    {
                        fStream.Write(buffer, 0, readCount);
                        readCount = ftpStream.Read(buffer, 0, bufferSize);
                    }

                    ftpStream.Close();
                    fStream.Close();
                    response.Close();
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
