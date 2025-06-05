using System.Security.Cryptography;
using System.Text;
using Idp.Application.Members.Abstractions.Commands;
using Idp.Contract.Authentication.Response;
using Idp.Domain.Services.Aws;

namespace Idp.Application.Members.Commands.Authentication.Authorize.Code;

public class CodeAuthorizeCommandHandler : ICommandHandler<CodeAuthorizeCommand, CodeAuthorizeResponse>
{
    
    private readonly IKmsService _kmsService;

    public CodeAuthorizeCommandHandler(IKmsService kmsService)
    {
        _kmsService = kmsService;
    }

    public async Task<CodeAuthorizeResponse> Handle(CodeAuthorizeCommand request, CancellationToken cancellationToken)
    {
        var str = "teste"u8.ToArray();

        var key = "99ae85f0-8f2c-42e2-aef8-0e872a1e51f0";
        
        var sign = await _kmsService.SignAsync(key, str);

        var isSigned = await _kmsService.VerifySignAsync(key, "str"u8.ToArray(), sign);

        return new CodeAuthorizeResponse($"{isSigned}");
    }
}