using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace courseworkBackend.Entities
{
	public class UserWorkoutEnrollmentModel
	{
		
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public UserModel User { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        //workout plan
        public WorkoutPlanModel WorkoutPlan { get; set; }

        [ForeignKey("WorkoutPlan")]
        public int WorkoutPlanId { get; set; }
        public int Days { get; set; }
        public int CompletedDays { get; set; }
        public DateTime StartDate { get; set; }
        public string Status { get; set; }
	}
}

