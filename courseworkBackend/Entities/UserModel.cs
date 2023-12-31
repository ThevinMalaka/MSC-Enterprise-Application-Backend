﻿using System;
namespace courseworkBackend.Entities
{
	public class UserModel
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password {get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public DateTime DateOfBirth { get; set; }

        public ICollection<UserWorkoutModel> UserWorkout { get; set; }
        public ICollection<UserWeightModel> WeightLog { get; set; }
        public ICollection<PredictionModel> Prediction { get; set; }
        public ICollection<UserWorkoutEnrollmentModel> UserWorkoutEnrollment { get; set; }

    }

    public class UserLoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
