using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using courseworkBackend.DataStore;
using courseworkBackend.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// JWT
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace courseworkBackend.Controllers
{

    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private readonly FitnessDbContext _context;

        public UserController(FitnessDbContext context)
        {
            _context = context;
        }

        // Action to create a new user
        [HttpPost("create")]
        public IActionResult Create([FromBody] UserModel user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(user);  // Return the created user with the generated ID
        }

        // Action to get all users
        [HttpGet("all")]
        // [Authorize]
        public IActionResult GetAll()
        {
            List<UserModel> users = _context.Users.ToList();
            return Ok(users);  // Return all users as JSON
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginModel user)
        {
            // Find the user with the given email and password
            UserModel foundUser = _context.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            if (foundUser == null)
            {
                return NotFound("User not found");
            }

            // Generate the JWT token
            string token = GenerateJwtToken(foundUser);

            // Return the user and the token
            return Ok(new { user = foundUser, token = token });
        }

        // JWT Authentication
        private string GenerateJwtToken(UserModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMySuperSecretKeyForFitnessAppInMyMSCourseWork"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim("id", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: "thevinmalaka.com",
                audience: "thevinmalaka.com",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}

