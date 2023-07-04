﻿using System;
namespace courseworkBackend.Entities
{
	public class UserModel
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password {get; set; }
        public double CurrentHeight { get; set; }
        public double CurrentWeight { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public class UserLoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}