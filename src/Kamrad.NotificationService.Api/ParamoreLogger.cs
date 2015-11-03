using System;
using paramore.brighter.commandprocessor.Logging;

namespace Kamrad.NotificationService.Api
{
    public class ParamoreLogger : ILog
    {
        private readonly Common.Logging.ILog logger;

        public ParamoreLogger(Common.Logging.ILog logger)
        {
            this.logger = logger;
        }

        public bool Log(LogLevel logLevel, Func<string> messageFunc, Exception exception = null, params object[] formatParameters)
        {
            if (messageFunc == null)
            {
                logger.Info("erdal was here!");
                return false;
            }

            switch (logLevel)
            {
                case LogLevel.Debug:
                case LogLevel.Trace:
                    logger.DebugFormat(messageFunc(), exception, formatParameters);
                    break;
                case LogLevel.Info:
                    logger.InfoFormat(messageFunc(), exception, formatParameters);
                    break;
                case LogLevel.Warn:
                    logger.WarnFormat(messageFunc(), exception, formatParameters);
                    break;
                case LogLevel.Error:
                    logger.ErrorFormat(messageFunc(), exception, formatParameters);
                    break;
                case LogLevel.Fatal:
                    logger.FatalFormat(messageFunc(), exception, formatParameters);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null);
            }


            return true;
        }
    }
}