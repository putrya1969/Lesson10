using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionApp
{
    [Serializable]
    public class InvalidUserInputException : Exception
    {
        public InvalidUserInputException() : base() { }
        public InvalidUserInputException(string message) : base(message) { }
        public InvalidUserInputException(string message, Exception inner) : base(message, inner) { }
    }
}
