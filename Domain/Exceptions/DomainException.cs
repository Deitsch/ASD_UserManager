using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    /// <summary>
    ///     Signals an error in the domain.
    /// </summary>
    public class DomainException : Exception
    {
        internal DomainException(string message) : base(message)
        { }

        internal DomainException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
