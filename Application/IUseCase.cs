using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    /// <summary>
    ///     A use case as defined by clean architecture which contains the application logic and orchestrates the domain to fulfill the given request.
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public interface IUseCase<in TRequest, TResponse>
    {
        /// <summary>
        ///     Executes the use case.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        TResponse Execute(TRequest request);
    }
}
