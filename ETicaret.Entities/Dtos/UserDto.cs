﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Entities.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string? NewPassword { get; set; }
    }
}
