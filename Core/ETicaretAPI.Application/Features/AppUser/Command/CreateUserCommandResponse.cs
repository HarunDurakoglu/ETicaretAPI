﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.AppUser.Command
{
    public class CreateUserCommandResponse
    {
        public bool Succeded { get; set; }
        public string Message { get; set; }
    }
}