using HRManagementApp.Dtos;
using HRManagementApp.Interfaces;
using HRManagementApp.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace HRManagementApp.Controllers
{
    [Route("api")]
    [ApiController]
    public class RegisterController(IRegisterRepository registerRepo) : ControllerBase
    {
        private readonly IRegisterRepository _registerRepo = registerRepo;

        [HttpPost("register")]
        public async Task<IActionResult> RegisterStaff([FromBody] RegisterStaffDto staffDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var registerModel = staffDto.ToRegisterFromRegisterStaffDto();
            await _registerRepo.RegisterStaffAsync(registerModel);

            return CreatedAtAction(nameof(GetStaffById), new { id = registerModel.Id }, registerModel.ToRegisterDto());
        }

        [HttpGet("retrieval")]
        public async Task<IActionResult> GetStaffById([FromRoute] int? id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var allStaff = await _registerRepo.GetAllStaffAsync();
            var staffDto = allStaff.Select(s => s.ToRegisterDto());
            return Ok(staffDto);
        }

        [HttpGet("retrieval/{id:int}")]
        public async Task<IActionResult> GetStaffById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var staff = await _registerRepo.GetStaffByIdAsync(id);
            if (staff == null)
                return NotFound();

            return Ok(staff.ToRegisterDto());
        }


        [HttpPut]
        [Route("update/{id:int}")]
        public async Task<IActionResult> UpdateStaff([FromRoute] int id, [FromBody] UpdateStaffRegisterDto staffDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var registerModel = await _registerRepo.UpdateStaffRegisterAsync(id, staffDto);

            if (registerModel == null)
            {
                return NotFound();
            }    

            return Ok(registerModel.ToRegisterDto());
        }
    }
}
