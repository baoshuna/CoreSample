﻿using System.ComponentModel.DataAnnotations;

namespace AuthSignalrChat.Models
{
    public class User
    {
        [Required]
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
