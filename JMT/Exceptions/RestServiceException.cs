using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMT.Exceptions
{
    public class RestServiceException : BaseException
    {
        public RestServiceException(string Message, System.Exception ex = null) : base(Message, ex) { }
        public RestServiceException(int errorNumber, string Message, System.Exception ex = null) : base(errorNumber, Message, ex) { }
    }
}
