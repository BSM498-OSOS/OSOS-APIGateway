﻿using Core.Entities;

namespace Entities.DTOs.AuthApiDTOs
{
    public class UserForRegisterDto : IDto
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordValidation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
