using ETicaretAPI.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.AppUser.Command.LoginUser
{
    public class LoginUserCommandResponse
    {
        public Token Token { get; set; }
    }
}
