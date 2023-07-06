using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using courseworkBackend.DataStore;
using courseworkBackend.DTO;
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


        [HttpGet]
        public async Task<ActionResult<List<WorkoutPlanDTO>>> GetWorkoutPlansAsync()
        {
            return await _workoutPlanService.GetWorkoutPlansAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkoutPlanDTO>> GetWorkoutPlanByIdAsync(int id)
        {
            return await _workoutPlanService.GetWorkoutPlanWithWorkoutsByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<WorkoutPlanDTO>> CreateWorkoutPlanAsync(WorkoutPlanModel workoutPlan)
        {
            return await _workoutPlanService.CreateWorkoutPlanAsync(workoutPlan);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WorkoutPlanDTO>> UpdateWorkoutPlanAsync(int id, WorkoutPlanModel workoutPlan)
        {
            if (id != workoutPlan.Id)
            {
                return BadRequest();
            }

            return await _workoutPlanService.UpdateWorkoutPlanAsync(workoutPlan);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WorkoutPlanDTO>> DeleteWorkoutPlanAsync(int id)
        {
            return await _workoutPlanService.DeleteWorkoutPlanAsync(id);
        }

        // // GET: api/WorkoutPlan
        // [HttpGet]
        // public IActionResult Get()
        // {
        //     var workoutPlans = _workoutPlanService.GetAll();
        //     return Ok(workoutPlans);
        // }

        // // GET: api/WorkoutPlan/5
        // [HttpGet("{id}")]
        // public IActionResult Get(int id)
        // {
        //     var workoutPlan = _workoutPlanService.GetById(id);
        //     if (workoutPlan == null)
        //     {
        //         return NotFound();
        //     }

        //     return Ok(workoutPlan);
        // }

        // // POST: api/WorkoutPlan
        // [HttpPost]
        // public IActionResult Post([FromBody] WorkoutPlanModel workoutPlanModel)
        // {
        //     var createdWorkoutPlan = _workoutPlanService.Create(workoutPlanModel);
        //     return CreatedAtAction(nameof(Get), new { id = createdWorkoutPlan.Id }, createdWorkoutPlan);
        // }

    }
}

