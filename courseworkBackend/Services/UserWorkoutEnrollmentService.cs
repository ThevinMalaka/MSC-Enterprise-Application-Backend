using System;
using courseworkBackend.DataStore;
using courseworkBackend.DTO;
using courseworkBackend.Entities;
using Microsoft.EntityFrameworkCore;

namespace courseworkBackend.Services
{
	public class UserWorkoutEnrollmentService
	{
		private readonly FitnessDbContext _context;

        public UserWorkoutEnrollmentService(FitnessDbContext context)
        {
            _context = context;
        }

		
        public async Task<List<UserWorkoutEnrollmentModel>> GetUserWorkoutEnrollmentsByUserIdAsync(int id)
        {
            return await _context.UserWorkoutEnrollments.Where(uwe => uwe.UserId == id).ToListAsync();
        }
        
        public async Task<UserWorkoutEnrollmentModel> GetUserWorkoutEnrollmentByIdAsync(int id)
        {
            return await _context.UserWorkoutEnrollments.FindAsync(id);
        }

        public async Task<UserWorkoutEnrollmentModel> CreateUserWorkoutEnrollmentAsync(UserWorkoutEnrollmentCreateDTO userWorkoutEnrollment)
        {
            
            var newUserWorkoutEnrollment = new UserWorkoutEnrollmentModel
            {
                UserId = userWorkoutEnrollment.UserId,
                WorkoutPlanId = userWorkoutEnrollment.WorkoutPlanId,
                Date = userWorkoutEnrollment.Date,
                CompletedDays = userWorkoutEnrollment.CompletedDays,
                StartDate = userWorkoutEnrollment.StartDate,
                Status = "ACTIVE"
            };

            object value = _context.UserWorkoutEnrollments.Add(newUserWorkoutEnrollment);
            await _context.SaveChangesAsync();
            return newUserWorkoutEnrollment;

        }

        public async Task<UserWorkoutEnrollmentModel> UpdateUserWorkoutEnrollmentAsync(UserWorkoutEnrollmentUpdateDTO userWorkoutEnrollment)
        {
            var existingUserWorkoutEnrollment = await _context.UserWorkoutEnrollments.FindAsync(userWorkoutEnrollment.Id);

            // Update the properties of the existing user entity
            existingUserWorkoutEnrollment.CompletedDays = userWorkoutEnrollment.CompletedDays;
            existingUserWorkoutEnrollment.Status = userWorkoutEnrollment.Status;

            _context.UserWorkoutEnrollments.Update(existingUserWorkoutEnrollment);
            await _context.SaveChangesAsync();
            return existingUserWorkoutEnrollment;
        }
	}
}

