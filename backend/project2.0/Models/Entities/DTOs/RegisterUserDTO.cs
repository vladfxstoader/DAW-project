﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project2._0.Models.Entities.DTOs
{
    public class RegisterUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
