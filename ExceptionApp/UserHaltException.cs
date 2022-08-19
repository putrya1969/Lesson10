using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionApp
{
    [Serializable]
    public class UserHaltException : Exception
    {
        public UserHaltException() : base() { }
        public UserHaltException(string message) : base(message) { }
        public UserHaltException(string message, Exception inner) : base(message, inner) { }
    }
}
