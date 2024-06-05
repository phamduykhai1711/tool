using System;
using System.IO;

//using System.Data.OracleClient;




namespace SolomonInvoice
{
    public class LoggerInfo
    {
        #region [Variables]

        private int _LogID;

        public int LogID
        {
            get { return _LogID; }
            set { _LogID = value; }
        }
        private string _LogApp;

        public string LogApp
        {
            get { return _LogApp; }
            set { _LogApp = value; }
        }
        private string _LogFunction;

        public string LogFunction
        {
            get { return _LogFunction; }
            set { _LogFunction = value; }
        }
        private string _LogType;

        public string LogType
        {
            get { return _LogType; }
            set { _LogType = value; }
        }
        private string _UserLogged;

        public string UserLogged
        {
            get { return _UserLogged; }
            set { _UserLogged = value; }
        }
        private string _LogMessage;

        public string LogMessage
        {
            get { return _LogMessage; }
            set { _LogMessage = value; }
        }

        #endregion
    }

    public class LogController
    {

        public static void LogBatchFileProcess(string content, string strPath)
        {
            try
            {
                if (strPath == "") 
                strPath = "c:\\";
                if (strPath != "")
                {
                    string strFileName = string.Format("Process_{0}{1}", DateTime.Now.ToString(CONST._DATE_FORMAT_ddMMyyyy), CONST._DOT_TXT);
                    if (File.Exists(string.Format("{0}\\{1}", strPath, strFileName)))
                    {
                        using (var fs = new FileStream(strPath + "\\" + strFileName, FileMode.Append, FileAccess.Write))
                        {
                            if (null != fs)
                            {
                                using (var sw = new StreamWriter(fs))
                                {
                                    var strLog = string.Format("{0} | {1}", DateTime.Now.ToString(CONST._DATETIME_FORMAT), content);
                                    sw.WriteLine(strLog);
                                    sw.Flush();
                                }
                            }
                        }
                    }
                    else
                    {
                        using (var fs = new FileStream(string.Format("{0}\\{1}", strPath, strFileName), FileMode.OpenOrCreate, FileAccess.ReadWrite))
                        {
                            if (null != fs)
                            {
                                using (var sw = new StreamWriter(fs))
                                {
                                    var strLog = string.Format("{0} | {1}", DateTime.Now.ToString(CONST._DATETIME_FORMAT), content);

                                    sw.WriteLine(strLog);
                                    sw.Flush();
                                }
                            }
                        }
                    }
                }
            }
            catch { }
        }

        public static void WriteFileLog(string LogApp, string LogFunction, string LogType, string UserLogged, string LogMessage , string strFilePath)
        {
            try
            {
                

                if (strFilePath == "")
                {
                    strFilePath = "C:\\";
                }

                if (strFilePath != "")
                {
                    string strFileName = string.Format("Error_{0}{1}", DateTime.Now.ToString(CONST._DATE_FORMAT_ddMMyyyy), CONST._DOT_TXT);

                    if (File.Exists(string.Format("{0}\\{1}", strFilePath, strFileName)))
                    {
                        using (var fs = new FileStream(string.Format("{0}\\{1}", strFilePath, strFileName), FileMode.Append, FileAccess.Write))
                        {
                            if (null != fs)
                            {
                                using (var sw = new StreamWriter(fs))
                                {
                                    var strLog = string.Format("{0} | {1} | {2} | {3} | {4} | {5}", DateTime.Now.ToString(CONST._DATETIME_FORMAT), LogApp, LogFunction, LogType, UserLogged, LogMessage);

                                    sw.WriteLine(strLog);
                                    sw.Flush();
                                }
                            }
                        }
                    }
                    else
                    {
                        using (var fs = new FileStream(string.Format("{0}\\{1}", strFilePath, strFileName), FileMode.OpenOrCreate, FileAccess.ReadWrite))
                        {
                            if (null != fs)
                            {
                                using (var sw = new StreamWriter(fs))
                                {
                                    var strLog = string.Format("{0} | {1} | {2} | {3} | {4} | {5}", DateTime.Now.ToString(CONST._DATETIME_FORMAT), LogApp, LogFunction, LogType, UserLogged, LogMessage);

                                    sw.WriteLine(strLog);
                                    sw.Flush();
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                //throw ex;
            }
        }

        public static void WriteLog(string LogApp, string LogFunction, string LogType, string UserLogged, string LogMessage,string filePath)
        {
            WriteFileLog(LogApp, LogFunction, LogType, UserLogged, LogMessage,filePath);
        }
    }

    public static class LogType
    {
        #region [Constants]

        public const string Information = "Information";
        public const string Warning = "Warning";
        public const string Exception = "Problem";

        #endregion
    }

    public static class LogApp
    {
        #region [Constants]

        public const string BatchfileApp = "BackupService";

        #endregion
    }
}
