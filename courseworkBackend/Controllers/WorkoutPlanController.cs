using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using courseworkBackend.DataStore;
using courseworkBackend.Entities;
using courseworkBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace courseworkBackend.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class WorkoutPlanController : ControllerBase
    {
        private readonly WorkoutPlanService _workoutPlanService;

        public WorkoutPlanController(FitnessDbContext context)
        {
            _workoutPlanService = new WorkoutPlanService(context);
        }

        // GET: api/WorkoutPlan
        [HttpGet]
        public IActionResult Get()
        {
            var workoutPlans = _workoutPlanService.GetAll();
            return Ok(workoutPlans);
        }

        // GET: api/WorkoutPlan/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var workoutPlan = _workoutPlanService.GetById(id);
            if (workoutPlan == null)
            {
                return NotFound();
            }

            return Ok(workoutPlan);
        }

        // POST: api/WorkoutPlan
        [HttpPost]
        public IActionResult Post([FromBody] WorkoutPlanModel workoutPlanModel)
        {
            var createdWorkoutPlan = _workoutPlanService.Create(workoutPlanModel);
            return CreatedAtAction(nameof(Get), new { id = createdWorkoutPlan.Id }, createdWorkoutPlan);
        }

        // More actions (PUT, DELETE) could be implemented here as per your needs...
    }
}

