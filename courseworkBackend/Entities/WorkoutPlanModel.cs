using System;
using courseworkBackend.DTO;

namespace courseworkBackend.Entities
{
	public class WorkoutPlanModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Difficulty { get; set; }
		public int Duration { get; set; }
		public double TotalMET { get; set; }
		// public ICollection<WorkoutPlanItemDTO> WorkoutPlanItems { get; set; }
		public ICollection<WorkoutPlanItemsModel> WorkoutPlanItems { get; set; }
		// public int Id { get; set; }
		// public string Name { get; set; }
		// public string Description { get; set; }
		// public string Difficulty { get; set; }
		// public string Duration { get; set; }
		// // MET = Metabolic Equivalent of Task
		// public double TotalMET { get; set; }

		// public ICollection<WorkoutPlanItemsModel> WorkoutPlanItems { get; set; }
        // public ICollection<UserWorkoutEnrollmentModel> UserWorkoutEnrollment { get; set; }
	}
}

