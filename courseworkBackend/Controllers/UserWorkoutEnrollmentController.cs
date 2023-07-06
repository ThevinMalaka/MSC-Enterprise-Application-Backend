using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using courseworkBackend.Services;
using courseworkBackend.Entities;
using courseworkBackend.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace courseworkBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserWorkoutEnrollmentController : ControllerBase
    {
        private readonly UserWorkoutEnrollmentService _userWorkoutEnrollmentService;
        private readonly PredictionService _predictionService;

        public UserWorkoutEnrollmentController(PredictionService predictionService,UserWorkoutEnrollmentService userWorkoutEnrollmentService)
        {
            _userWorkoutEnrollmentService = userWorkoutEnrollmentService;
            _predictionService = predictionService;
        }


        [HttpGet("user/{userId}")]
        public async Task<List<UserWorkoutEnrollmentModel>> Get(int userId)
        {
           //get all user workout enrollments from the database
           return await _userWorkoutEnrollmentService.GetUserWorkoutEnrollmentsByUserIdAsync(userId);
        }

        [HttpGet("single/{id}")]
        public async Task<UserWorkoutEnrollmentModel> GetEnrollmentById(int id)
        {
           //get all user workout enrollments from the database
           return await _userWorkoutEnrollmentService.GetUserWorkoutEnrollmentByIdAsync(id);
        }

        //add a new user workout enrollment
        [HttpPost("single")]
        public async Task<ActionResult<UserWorkoutEnrollmentModel>> Post(UserWorkoutEnrollmentCreateDTO userWorkoutEnrollment)
        {
            //    //create a new user workout enrollment
            //    var result = await _userWorkoutEnrollmentService.CreateUserWorkoutEnrollmentAsync(userWorkoutEnrollment);
            //    return result; 

            //create a new user workout enrollment
            var result = await _userWorkoutEnrollmentService.CreateUserWorkoutEnrollmentAsync(userWorkoutEnrollment);
            var userId = userWorkoutEnrollment.UserId;
            // print out the user id
            Console.WriteLine("User ID:--------------------- " + userId);

            //create a new prediction
            var predictionResult = await _predictionService.CreatePredictionAsync(userId);
            return result; 

        }

        //update a user workout enrollment
        [HttpPut("single")]
        public async Task<ActionResult<UserWorkoutEnrollmentModel>> Put(UserWorkoutEnrollmentUpdateDTO userWorkoutEnrollment)
        {
           //update a user workout enrollment
           var result = await _userWorkoutEnrollmentService.UpdateUserWorkoutEnrollmentAsync(userWorkoutEnrollment);
           return result; 

        }

         //complete single day workout
        [HttpPut("complete/{id}")]
        public async Task<ActionResult<UserWorkoutEnrollmentModel>> CompleteDay(int id)
        {
            //complete a single day workout
            var result = await _userWorkoutEnrollmentService.CompleteDayAsync(id);
            return result; 
            
        }

        //-----------------

        // [HttpGet("{id}")]
        // public async Task<IActionResult> GetUserWorkoutEnrollment(int id)
        // {
        //     var userWorkoutEnrollment = await _userWorkoutEnrollmentService.GetUserWorkoutEnrollmentByIdAsync(id);

        //     if (userWorkoutEnrollment == null)
        //     {
        //         return NotFound();
        //     }

        //     return Ok(userWorkoutEnrollment);
        // }

        // [HttpGet("user/{userId}")]
        // public async Task<IActionResult> GetUserWorkoutEnrollments(int userId)
        // {
        //     var userWorkoutEnrollments = await _userWorkoutEnrollmentService.GetUserWorkoutEnrollmentsByUserIdAsync(userId);

        //     if (userWorkoutEnrollments == null)
        //     {
        //         return NotFound();
        //     }

        //     return Ok(userWorkoutEnrollments);
        // }

        // [HttpPost]
        // public async Task<IActionResult> CreateUserWorkoutEnrollment(UserWorkoutEnrollmentModel userWorkoutEnrollment)
        // {
        //     var createdUserWorkoutEnrollment = await _userWorkoutEnrollmentService.CreateUserWorkoutEnrollmentAsync(userWorkoutEnrollment);
        //     return CreatedAtAction(nameof(GetUserWorkoutEnrollment), new { id = createdUserWorkoutEnrollment.Id }, createdUserWorkoutEnrollment);
        // }
    }
}

