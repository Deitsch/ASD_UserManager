using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    /// <summary>
    ///     Signals an error in the application.
    /// </summary>
    public class AppException : Exception
    {
        internal AppException(string message) : base(message)
        { }

        internal AppException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
