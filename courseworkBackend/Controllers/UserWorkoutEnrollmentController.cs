using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using courseworkBackend.Services;
using courseworkBackend.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace courseworkBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserWorkoutEnrollmentController : ControllerBase
    {
        private readonly UserWorkoutEnrollmentService _userWorkoutEnrollmentService;

        public UserWorkoutEnrollmentController(UserWorkoutEnrollmentService userWorkoutEnrollmentService)
        {
            _userWorkoutEnrollmentService = userWorkoutEnrollmentService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserWorkoutEnrollment(int id)
        {
            var userWorkoutEnrollment = await _userWorkoutEnrollmentService.GetUserWorkoutEnrollmentByIdAsync(id);

            if (userWorkoutEnrollment == null)
            {
                return NotFound();
            }

            return Ok(userWorkoutEnrollment);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserWorkoutEnrollments(int userId)
        {
            var userWorkoutEnrollments = await _userWorkoutEnrollmentService.GetUserWorkoutEnrollmentsByUserIdAsync(userId);

            if (userWorkoutEnrollments == null)
            {
                return NotFound();
            }

            return Ok(userWorkoutEnrollments);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserWorkoutEnrollment(UserWorkoutEnrollmentModel userWorkoutEnrollment)
        {
            var createdUserWorkoutEnrollment = await _userWorkoutEnrollmentService.CreateUserWorkoutEnrollmentAsync(userWorkoutEnrollment);
            return CreatedAtAction(nameof(GetUserWorkoutEnrollment), new { id = createdUserWorkoutEnrollment.Id }, createdUserWorkoutEnrollment);
        }
    }
}

