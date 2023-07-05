using System;
using courseworkBackend.Entities;
using Microsoft.EntityFrameworkCore;

namespace courseworkBackend.DataStore
{
	public class FitnessDbContext : DbContext
    {
        public FitnessDbContext(DbContextOptions<FitnessDbContext> options)
        : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<WorkoutPlanModel> WorkoutPlans { get; set; }
        public DbSet<CheatMeal> CheatMeals { get; set; }
    }
}

