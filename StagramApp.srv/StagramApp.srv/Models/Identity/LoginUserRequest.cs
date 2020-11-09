﻿using System.ComponentModel.DataAnnotations;

namespace StagramApp.srv.Models.Identity
{
    public class LoginUserRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}