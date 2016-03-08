using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Data.Exceptions
{
    [Serializable]
    public class DuplicateDataFoundException : Exception
    {
        public DuplicateDataFoundException(string message)
            : base(message)
        {

        }
    }
}
