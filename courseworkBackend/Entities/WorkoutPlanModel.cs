using System;
namespace courseworkBackend.Entities
{
	public class WorkoutPlanModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Difficulty { get; set; }
		public string Duration { get; set; }
		// MET = Metabolic Equivalent of Task
		public double MET { get; set; }
	}
}

