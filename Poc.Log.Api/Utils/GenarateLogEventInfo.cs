using System;

namespace Poc.Log.Api.Utils
{
    public static class GenarateLogEventInfo
    {
        public static NLog.LogEventInfo CreateObjectLog(ENUMLogType oLogType, string sMessage, int nIdInternalCode, DateTime? dtStart, DateTime? dtFinish, int nIdMensagem, string sSource = null, Exception oException = null, string sGuid = null, string sPhone = null)
        {
            NLog.LogEventInfo oLogEventInfo;

            try
            {
                switch (oLogType)
                {
                    case ENUMLogType.Info: // INFO
                        oLogEventInfo = new NLog.LogEventInfo(NLog.LogLevel.Info, "", sMessage);
                        break;
                    case ENUMLogType.Debug: // DEBUG
                        oLogEventInfo = new NLog.LogEventInfo(NLog.LogLevel.Debug, "", sMessage);
                        break;
                    case ENUMLogType.Error: // ERROR
                        oLogEventInfo = new NLog.LogEventInfo(NLog.LogLevel.Error, "", sMessage);
                        break;
                    case ENUMLogType.Trace: // TRACE
                        oLogEventInfo = new NLog.LogEventInfo(NLog.LogLevel.Trace, "", sMessage);
                        break;
                    default:
                        oLogEventInfo = new NLog.LogEventInfo();
                        break;
                }

                oLogEventInfo.Exception = oException;
                oLogEventInfo.Properties["IdMensagem"] = nIdMensagem.ToString();
                oLogEventInfo.Properties["IdInternalCode"] = nIdInternalCode.ToString();

                if (dtStart != null)
                    oLogEventInfo.Properties["dtStart"] = Convert.ToDateTime(dtStart).ToString("yyyy-MM-dd HH:mm:ss.fff");
                else
                    oLogEventInfo.Properties["dtStart"] = "";

                if (dtFinish != null)
                    oLogEventInfo.Properties["dtFinish"] = Convert.ToDateTime(dtFinish).ToString("yyyy-MM-dd HH:mm:ss.fff");
                else
                    oLogEventInfo.Properties["dtFinish"] = "";

                if (sSource == null) sSource = "";
                oLogEventInfo.Properties["sSource"] = sSource;

                if (sGuid == null) sGuid = "";
                oLogEventInfo.Properties["sGuid"] = sGuid;

                if (sPhone == null) sPhone = "";
                oLogEventInfo.Properties["sPhone"] = sPhone;

                return oLogEventInfo;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

    public enum ENUMLogType
    {
        Info = 1,
        Debug = 2,
        Error = 3,
        Trace = 4
    }
}
