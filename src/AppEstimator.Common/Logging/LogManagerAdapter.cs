using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Common.Logging
{
    public class LogManagerAdapter : ILogManager
    {
        public ILog GetLog(Type requestedLogType)
        {
            var log = LogManager.GetLogger(requestedLogType);
            return log;
        }
    }
}
