﻿namespace backend_API.Model
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; } 
        public required string Role { get; set; } // Either "Admin" or "ServiceAdvisor"
    }
}
