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

namespace ETicaretAPI.Application.Features.AppUser.Command
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly IIdentityService _identityService;

        public CreateUserCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
           IdentityResult result = await _identityService.CreateUserAsync(request.Username, request.Email, request.NameSurname, request.Password);

            CreateUserCommandResponse response = new() { Succeded = result.Succeeded };

            if (result.Succeeded)
            {
                response.Message = "Kullanıcı başarıyla oluşturuldu";
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    response.Message += $"{item.Code} - {item.Description}<br>";
                }
            }
            return response;
        }
    }
}
