﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Entities.Dtos
{
    public class UserChangePasswordDto
    {
        public int UserId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
