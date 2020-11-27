using Api.DTOs;
using Api.Helpers;
using Api.Models;
using Api.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IConfiguration _configuration;

        public AttendanceController(UserManager<ApplicationUser> userManager, IAttendanceRepository attendanceRepository, IConfiguration configuration)
        {
            _userManager = userManager;
            _attendanceRepository = attendanceRepository;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CheckInDto model)
        {
            var helper = new Helper(_configuration, _userManager);
            var response = helper.VerifyToken(HttpContext);

            if (!response.Flagged)
            {
                return BadRequest(new { message = response.Message });
            }

            if (!model.CheckedIn)
            {
                return BadRequest(new { message = "Enter check in value" });
            }
            var attendance = new AttendanceModel
            {
                Id = Guid.NewGuid().ToString(),
                CheckedInAt = DateTime.Now,
                CheckedOutAt = DateTime.Now,
                CheckIn = model.CheckedIn,
                OwnerId = response.UserId,
                Reason = "no reason",
            };

            await _attendanceRepository.PostAttendance(attendance);

            return Created("", attendance);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var helper = new Helper(_configuration, _userManager);
            var response = helper.VerifyToken(HttpContext);

            if (!response.Flagged)
            {
                return BadRequest(new { message = response.Message });
            }

            var result = await _attendanceRepository.GetAllAttendance(response.UserId);

            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {

            var helper = new Helper(_configuration, _userManager);
            var response = helper.VerifyToken(HttpContext);

            if (!response.Flagged)
            {
                return BadRequest(new { message = response.Message });
            }

            var result = await _attendanceRepository.GetAttendance(response.UserId, id);

            return Ok(result);
        }
    }
}
