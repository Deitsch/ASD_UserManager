using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class ResourceNotExistingException : AppException
    {
        internal ResourceNotExistingException(string message) : base(message)
        {
        }

        internal ResourceNotExistingException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
