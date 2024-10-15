using HRManagementApp.Dtos;
using HRManagementApp.Interfaces;
using HRManagementApp.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace HRManagementApp.Controllers
{
    [Route("api")]
    [ApiController]
    public class RegisterController(IRegisterRepository registerRepo, IApiPerformanceLogger performanceLogger) : ControllerBase
    {
        private readonly IRegisterRepository _registerRepo = registerRepo;
        private readonly IApiPerformanceLogger _performanceLogger = performanceLogger;

        [HttpPost("register")]
        public async Task<IActionResult> RegisterStaff([FromBody] RegisterStaffDto staffDto)
        {
            if (!ModelState.IsValid)
            {
                await _performanceLogger.LogRequestAsync("/api/register", DateTime.Now, false);
                return BadRequest(ModelState);
            }

            try
            {
                var registerModel = staffDto.ToRegisterFromRegisterStaffDto();
                await _registerRepo.RegisterStaffAsync(registerModel);

                return CreatedAtAction(nameof(GetStaffById), new { id = registerModel.Id }, registerModel.ToRegisterDto());
            }
            catch (Exception ex) 
            {
                await _performanceLogger.LogRequestAsync($"/api/register", DateTime.Now, false);
                return StatusCode(500, ex.Message.ToString());
            }
        }

        [HttpGet("retrieval")]
        public async Task<IActionResult> GetStaffById()
        {
            if (!ModelState.IsValid)
            {
                await _performanceLogger.LogRequestAsync("/api/retrieval", DateTime.Now, false);
                return BadRequest(ModelState);
            }

            try
            {
                var allStaff = await _registerRepo.GetAllStaffAsync();
                var staffDto = allStaff.Select(s => s.ToRegisterDto());
                return Ok(staffDto);
            }
            catch (Exception ex)
            {
                await _performanceLogger.LogRequestAsync($"/api/retrieval", DateTime.Now, false);
                return StatusCode(500, ex.Message.ToString());
            }
        }

        [HttpGet("retrieval/{id:int}")]
        public async Task<IActionResult> GetStaffById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                await _performanceLogger.LogRequestAsync($"/api/retrieval/{id}", DateTime.Now, false);
                return BadRequest(ModelState);
            }

            try
            {
                var staff = await _registerRepo.GetStaffByIdAsync(id);
                if (staff == null)
                    return NotFound();

                return Ok(staff.ToRegisterDto());
            }
            catch (Exception ex)
            {
                await _performanceLogger.LogRequestAsync($"/api/retrieval/{id}", DateTime.Now, false);
                return StatusCode(500, ex.Message.ToString());
            }
        }

        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> UpdateStaff([FromRoute] int id, [FromBody] UpdateStaffRegisterDto staffDto)
        {
            if (!ModelState.IsValid)
            {
                await _performanceLogger.LogRequestAsync($"/api/update/{id}", DateTime.Now, false);
                return BadRequest(ModelState);
            }

            try
            {
                var registerModel = await _registerRepo.UpdateStaffRegisterAsync(id, staffDto);

                if (registerModel == null)
                {
                    return NotFound();
                }

                return Ok(registerModel.ToRegisterDto());
            }
            catch (Exception ex)
            {
                await _performanceLogger.LogRequestAsync($"/api/update/{id}", DateTime.Now, false);
                return StatusCode(500, ex.Message.ToString());
            }
        }
    }
}
