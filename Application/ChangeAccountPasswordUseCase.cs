using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IChangeAccountPasswordUseCase : IUseCase<ChangeAccountPasswordRequest, ChangeAccountPasswordResponse>
    {
    }

    public struct ChangeAccountPasswordRequest
    { }

    public struct ChangeAccountPasswordResponse
    { }

    public class ChangeAccountPasswordUseCase : IChangeAccountPasswordUseCase
    {
        public Task<ChangeAccountPasswordResponse> Execute(ChangeAccountPasswordRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
