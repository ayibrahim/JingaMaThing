using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMT.Exceptions
{
    public class BaseException : Exception
    {
        private int _errorNumber;

        public int ErrorNumber { get { return _errorNumber; } set { _errorNumber = value; } }

        public BaseException() : base() { }

        public BaseException(string message) : base(message) { }

        public BaseException(string message, Exception e) : base(message , e) { }

        public BaseException(int errorNumber, string message) : base(message) { _errorNumber = errorNumber; }

        public BaseException(int errorNumber, string message, Exception e) : base(message, e) { _errorNumber = errorNumber; }

        public BaseException(string machineName, string userName, string message, string application, string methodName, int errorNumber, string errorDesc, string url, Exception e, string details, long elapsedTransactionTime)
            : base(message, e) {
            _errorNumber = errorNumber;
        }
    }
}
