using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleWbClient.Utilities
{
    public class LogItem
    {
        private static readonly char msgSpan = '§';

        public bool IsMessage { get; private set; }

        public DateTime LogTime { get; private set; }

        public string TreadId { get; private set; }

        public string Level { get; private set; }

        public string StackInfo { get; private set; }

        public string MessageInfo { get; private set; }

        public LogItem(String line)
        {
            if (line == null)
            {
                return;
            }
            if (ContainLogTimeStr(line))
            {
                IsMessage = true;
                string str = line.Substring(0, 23);
                IFormatProvider format = new System.Globalization.CultureInfo("zh-CN");
                LogTime = DateTime.ParseExact(str, Log.TimeFormat, format);
                TreadId = fetchThread(line);
                Level = fetchLevel(line);
                StackInfo = fetchStack(line);
                MessageInfo = line.Substring(line.IndexOf(msgSpan) + 1).Trim();
            }
            else
            {
                IsMessage = false;
            }
        }

        private bool ContainLogTimeStr(string line)
        {
            // 日期正则表达式
            string reg = @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))";
            Match m = Regex.Match(line, reg);
            return m.Success;
        }

        private string fetchThread(string line)
        {
            Match m = Regex.Match(line, @"\[\d+\]");
            return m.Value;
        }

        private string fetchLevel(string line)
        {
            Match m = Regex.Match(line, @"\[\d+\]");
            if (m.Success)
            {
                return line.Substring(line.IndexOf(m.Value) + m.Value.Length + 1, 6).Trim();
            }

            return null;
        }

        private string fetchStack(string line)
        {
            Match m = Regex.Match(line, Level);
            if (m.Success)
            {
                int startIdx = line.IndexOf(m.Value) + m.Value.Length + 1;
                int endIdx = line.IndexOf(msgSpan);
                return line.Substring(startIdx, endIdx - startIdx).Trim();
            }

            return null;
        }
    }
}