using Castle.Core.Logging;
using Newtonsoft.Json;
using ShosBackend.Common.Enums;

namespace ShosBackend.Common.Helpers
{
    public interface ILoggerHelper
    {
        void LogObject(object messageObject, LoggerOption loggerOption);
    }

    public class LoggerHelper : ILoggerHelper
    {
        private readonly ILogger _logger;

        public LoggerHelper(ILogger logger)
        {
            _logger = logger;
        }

        public void LogObject(object messageObject, LoggerOption loggerOption)
        {
            var message = JsonConvert.SerializeObject(
                messageObject,
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                }
            );

            switch (loggerOption)
            {
                case LoggerOption.Debug:
                    _logger.Debug(message);
                    break;

                case LoggerOption.Info:
                    _logger.Info(message);
                    break;

                case LoggerOption.Warning:
                    _logger.Warn(message);
                    break;

                case LoggerOption.Error:
                    _logger.Error(message);
                    break;

                case LoggerOption.Fatal:
                    _logger.Fatal(message);
                    break;
            }
        }
    }
}
