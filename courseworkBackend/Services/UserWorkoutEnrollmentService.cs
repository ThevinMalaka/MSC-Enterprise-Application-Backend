using System;
using courseworkBackend.DataStore;
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

        //get user enrollments by userid
        public async Task<List<UserWorkoutEnrollmentModel>> GetUserWorkoutEnrollmentsByUserIdAsync(int id)
        {
            return await _context.UserWorkoutEnrollments.Where(uwe => uwe.UserId == id).ToListAsync();
        }
        
        public async Task<UserWorkoutEnrollmentModel> GetUserWorkoutEnrollmentByIdAsync(int id)
        {
            return await _context.UserWorkoutEnrollments.FindAsync(id);
        }

        public async Task<UserWorkoutEnrollmentModel> CreateUserWorkoutEnrollmentAsync(UserWorkoutEnrollmentModel userWorkoutEnrollment)
        {
            object value = _context.UserWorkoutEnrollments.Add(userWorkoutEnrollment);
            await _context.SaveChangesAsync();
            return userWorkoutEnrollment;
        }
	}
}

