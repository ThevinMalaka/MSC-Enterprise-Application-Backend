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
    public class UserWeightController : ControllerBase
    {
        private readonly UserWeightService _userWeightService;

        public UserWeightController(UserWeightService userWeightService)
        {
            _userWeightService = userWeightService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWeightLog(int id)
        {
            var weightLog = await _userWeightService.GetWeightLogByIdAsync(id);

            if (weightLog == null)
            {
                return NotFound();
            }

            return Ok(weightLog);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserWeightLogs(int userId)
        {
            var weightLogs = await _userWeightService.GetWeightLogsByUserIdAsync(userId);

            if (weightLogs == null)
            {
                return NotFound();
            }

            return Ok(weightLogs);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWeightLog(UserWeightModel weightLog)
        {
            var createdWeightLog = await _userWeightService.CreateWeightLogAsync(weightLog);
            return CreatedAtAction(nameof(GetWeightLog), new { id = createdWeightLog.Id }, createdWeightLog);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWeightLog(int id, UserWeightModel weightLog)
        {
            if (id != weightLog.Id)
            {
                return BadRequest();
            }

            var updatedWeightLog = await _userWeightService.UpdateWeightLogAsync(weightLog);

            return Ok(updatedWeightLog);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeightLog(int id)
        {
            var deletedWeightLog = await _userWeightService.DeleteWeightLogAsync(id);

            if (deletedWeightLog == null)
            {
                return NotFound();
            }

            return Ok(deletedWeightLog);
        }
    }
}

