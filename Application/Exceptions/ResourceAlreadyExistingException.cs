using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class ResourceAlreadyExistingException : AppException
    {
        public ResourceAlreadyExistingException(string message) : base(message)
        { }

        public ResourceAlreadyExistingException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
