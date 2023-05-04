namespace FeishuNotice.Common
{
    /// <summary>
    /// 日志文件
    /// </summary>
    public class LogFile
    {
        #region 初始化信息

        private bool _Error = false;
        private string _ErrorString = "";
        private bool _RootExist = false;
        private bool _SubExist = false;
        private bool _FileExist = false;

        //private string _FilePath = "";
        private System.IO.FileInfo _LogFile;

        /// <summary>
        /// Log文件[简化](相对路径System.AppDomain.CurrentDomain.BaseDirectory 默认./Log,后缀Log)
        /// </summary>
        /// <param name="LogSubName">子目录名</param>
        /// <param name="LogName">Log文件名</param>
        public LogFile(string LogSubName, string LogName)
            : this(LogSubName, LogName, "log")
        {
        }

        /// <summary>
        /// Log文件[简化](相对路径System.AppDomain.CurrentDomain.BaseDirectory 默认./Log)
        /// </summary>
        /// <param name="LogSubName">Log文件子目录</param>
        /// <param name="LogName">Log文件名</param>
        /// <param name="LogExtension">Log文件后缀</param>
        public LogFile(string LogSubName, string LogName, string LogExtension)
            : this("Log", LogSubName, LogName, LogExtension)
        {
        }

        /// <summary>
        /// Log文件[指定目录名]
        /// </summary>
        /// <param name="vLogPath">Log目录(相对于 System.AppDomain.CurrentDomain.BaseDirectory)</param>
        /// <param name="LogSubName">Log文件子目录</param>
        /// <param name="LogName">Log文件名</param>
        /// <param name="LogExtension">Log文件后缀</param>
        public LogFile(string vLogPath, string LogSubName, string LogName, string LogExtension)
            : this(System.AppDomain.CurrentDomain.BaseDirectory + vLogPath, LogSubName, LogName, LogExtension, true)
        {
        }

        /// <summary>
        /// Log文件[完整]
        /// </summary>
        /// <param name="LogPath">Log目录(完整路径)</param>
        /// <param name="LogSubName">Log文件子目录</param>
        /// <param name="LogName">Log文件名</param>
        /// <param name="LogExtension">Log文件后缀</param>
        /// <param name="AutoCreate">是否自动创建文件夹</param>
        public LogFile(string LogPath, string LogSubName, string LogName, string LogExtension, bool AutoCreate)
        {
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(LogPath);
            _RootExist = di.Exists;

            if (!_RootExist && AutoCreate)
            {
                //自动创建根文件夹
                AutoCreateDirectory(di);
                _RootExist = true;
            }
            if (_RootExist)
            {
                di = new System.IO.DirectoryInfo(LogPath + "\\" + LogSubName);
                _SubExist = di.Exists;

                if (!_SubExist && AutoCreate)
                {
                    //自动创建子文件夹
                    AutoCreateDirectory(di);
                    _SubExist = true;
                }
                else
                {
                    _Error = true;
                    _ErrorString = "Log子目录不存在且不创建";
                }
            }
            else
            {
                _Error = true;
                _ErrorString = "Log目录不存在";
            }
            _LogFile = new System.IO.FileInfo(LogPath + "\\" + LogSubName + "\\" + LogName + "." + LogExtension);
            _FileExist = _LogFile.Exists;
        }

        private void AutoCreateDirectory(System.IO.DirectoryInfo di)
        {
            if (!di.Exists)
            {
                System.IO.Directory.CreateDirectory(di.FullName);
            }
        }

        /// <summary>
        /// 是否出错
        /// </summary>
        public bool IsError
        {
            get { return _Error; }
        }

        /// <summary>
        /// 出错信息
        /// </summary>
        public string ErrorString
        {
            get { return _ErrorString; }
        }

        /// <summary>
        /// Log文件是否存在
        /// </summary>
        public bool IsLogExist
        {
            get { return _FileExist; }
        }

        public void Write(string info)
        {
            System.IO.StreamWriter w = System.IO.File.AppendText(_LogFile.FullName);
            w.WriteLine("{0}", info);
            w.Flush();
            w.Close();
        }

        #endregion 初始化信息

        #region static

        public enum LogFileType
        {
            Null,
            Year,
            Month,

            //Weak,
            Day,

            Hour,
            Minute,
            Second
        }

        public enum LogWriteType
        {
            Null,
            Date
        }

        /// <summary>
        /// 写日志基础
        /// </summary>
        /// <param name="LogSubName"></param>
        /// <param name="LogName"></param>
        /// <param name="type"></param>
        /// <param name="info"></param>
        private static void LogBase(string LogSubName, string LogName, LogFileType type, string info)
        {
            string nLogName = LogName;
            switch (type)
            {
                case LogFileType.Year:
                    nLogName += DateTime.Now.ToString("_yyyy");
                    break;

                case LogFileType.Month:
                    nLogName += DateTime.Now.ToString("_yyyyMM");
                    break;

                case LogFileType.Day:
                    nLogName += DateTime.Now.ToString("_yyyyMMdd");
                    break;
                //case LogFileType.Weak:
                //    nLogName += DateTime.Now.ToString("yyyy");
                //    break;
                case LogFileType.Hour:
                    nLogName += DateTime.Now.ToString("_yyyyMMdd_HH");
                    break;

                case LogFileType.Minute:
                    nLogName += DateTime.Now.ToString("_yyyyMMdd_HHmm");
                    break;

                case LogFileType.Second:
                    nLogName += DateTime.Now.ToString("_yyyyMMdd_HHmmss");
                    break;

                case LogFileType.Null:
                default:
                    nLogName += "";
                    break;
            }
            LogFile f = new LogFile(LogSubName, nLogName);
            f.Write(string.Format("{0}\t{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), info));
        }

        private static object ctx = new object();

        /// <summary>
        /// 日志锁定
        /// </summary>
        /// <param name="LogSubName"></param>
        /// <param name="LogName"></param>
        /// <param name="type"></param>
        /// <param name="info"></param>
        private static void LogSync(string LogSubName, string LogName, LogFileType type, string info)
        {
            lock (ctx)
            {
                LogBase(LogSubName, LogName, type, info);
                //System.Threading.Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// 写入日志（基本）
        /// </summary>
        /// <param name="LogSubName">子目录名</param>
        /// <param name="LogName">日志名前缀</param>
        /// <param name="type">单个日志记录时间</param>
        /// <param name="info">日志信息</param>
        public static void Log(string LogSubName, string LogName, LogFileType type, string info)
        {
            LogSync(LogSubName, LogName, type, info);
        }

        /// <summary>
        /// 程序出错
        /// </summary>
        /// <param name="ex">出错信息集</param>
        public static void Log(System.Exception ex)
        {
            string s = string.Format("{0}\r\n{1}\r\n-----------------", ex.Message, ex.ToString());
            Log("System", "Error", LogFileType.Day, s);
        }

        /// <summary>
        /// SQL出错
        /// </summary>
        /// <param name="type">类别</param>
        /// <param name="ex">出错信息集</param>
        /// <param name="sqlstring">SQL语句</param>
        public static void Log(string type, string ex, string sqlstring)
        {
            string s = string.Format("{0}\t{1}", ex.Replace("\r\n", "|"), sqlstring);
            Log("SQL", type, LogFileType.Day, s);
        }

        #endregion static
    }
}