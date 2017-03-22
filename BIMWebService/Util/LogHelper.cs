using System;
using log4net;

namespace BIMWebService.Util
{
    public static class LogHelper
    {
        public static readonly ILog Loginfo = LogManager.GetLogger("loginfo");
        public static readonly ILog Logerror = LogManager.GetLogger("logerror");

        public static void WriteLog(string info)
        {
            if (Loginfo.IsInfoEnabled)
            {
                Loginfo.Info(info);
            }
        }
        public static void WriteLog(string info, Exception se)
        {
            if (Logerror.IsErrorEnabled)
            {
                Logerror.Error(info, se);
            }
        }
    }
}