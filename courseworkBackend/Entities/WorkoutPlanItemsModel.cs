using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace courseworkBackend.Entities
{
	public class WorkoutPlanItemsModel
	{
	  	public int Id { get; set; }

        public WorkoutPlanModel WorkoutPlan { get; set; }
        
        [ForeignKey("WorkoutPlan")]
        public int WorkoutPlanId { get; set; }

        public WorkoutModel Workout { get; set; }

        [ForeignKey("Workout")]
        public int WorkoutId { get; set; }

        public int Order { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int Rest { get; set; }

	}
}

