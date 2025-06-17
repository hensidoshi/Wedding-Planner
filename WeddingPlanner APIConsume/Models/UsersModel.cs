﻿namespace WeddingPlanner_APIConsume.Models
{
    public class UsersModel
    {
        public int? UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Role { get; set; } = "";
    }

    public class ErrorResponse
    {
        public string Message { get; set; }
    }
}
