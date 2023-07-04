using System;
using courseworkBackend.DataStore;
using courseworkBackend.Entities;

namespace courseworkBackend.Services
{
	public class WorkoutPlanService
	{
		private readonly FitnessDbContext _context;

		public WorkoutPlanService(FitnessDbContext context)
		{
			_context = context;
		}

		// Get all workout plans
		public List<WorkoutPlanModel> GetAll()
		{
			List<WorkoutPlanModel> workoutPlans = _context.WorkoutPlans.ToList();
			return workoutPlans;
		}

		// Get a workout plan by ID
		public WorkoutPlanModel GetById(int id)
		{
			WorkoutPlanModel workoutPlan = _context.WorkoutPlans.FirstOrDefault(w => w.Id == id);
			return workoutPlan;
		}

		// Create a new workout plan
		public WorkoutPlanModel Create(WorkoutPlanModel workoutPlan)
		{
			_context.WorkoutPlans.Add(workoutPlan);
			_context.SaveChanges();

			return workoutPlan;
		}

	}
}

