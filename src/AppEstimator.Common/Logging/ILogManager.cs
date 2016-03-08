using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Common.Logging
{
    public interface ILogManager
    {
        ILog GetLog(Type requestedLogType);
    }
}
