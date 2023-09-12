using ETicaretAPI.Application.Abstractions.Token;
using ETicaretAPI.Application.Dtos;
using ETicaretAPI.Application.Exceptions;
using ETicaretAPI.Application.Identity;
using ETicaretAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.AppUser.Command.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly IIdentityService _identityService;
        readonly ITokenHandler _tokenHandler;

        public LoginUserCommandHandler(IIdentityService identityService, ITokenHandler tokenHandler)
        {
            _identityService = identityService;
            _tokenHandler = tokenHandler;
        }
        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            User user = await _identityService.GetUserAsync(request.UsernameOrEmail);
            if (user == null)
            {
                //user = await _identityService.FindByEmailAsync(request.UsernameOrEmail);
            }
            if (user == null)
            {
                throw new NotFoundUserException("Kullanıcı bilgisi veya şifre hatalı");
            }

            SignInResult result = null; //_identityService.checkpassword
            if (result.Succeeded)
            {
                Token token = _tokenHandler.CreateAccessToken(5);
                return new()
                {
                    Token = token
                };
            }
            return new();
        }
    }
}
