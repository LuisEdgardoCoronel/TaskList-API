﻿namespace TaskList_API.Model
{
    public class UserModel
    {
        public Guid UserId { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}
