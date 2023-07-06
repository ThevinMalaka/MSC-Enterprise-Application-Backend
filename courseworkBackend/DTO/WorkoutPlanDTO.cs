using System;
namespace courseworkBackend.DTO
{
	public class WorkoutPlanDTO
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Difficulty { get; set; }
        public string Duration { get; set; }
        public double TotalMET { get; set; }
        public ICollection<WorkoutPlanItemDTO> WorkoutPlanItems { get; set; }
    }
}

