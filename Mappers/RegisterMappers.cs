using HRManagementApp.Dtos;
using HRManagementApp.Models;

namespace HRManagementApp.Mappers
{
    public static class RegisterMappers
    {
        public static RegisterDto ToRegisterDto(this Register registerModel)
        {
            return new RegisterDto
            {
                Id = registerModel.Id,
                Surname = registerModel.Surname,
                OtherNames = registerModel.OtherNames,
                DateOfBirth = registerModel.DateOfBirth,
                StaffAccessCode = registerModel.StaffAccessCode,
                EmployeeNumber = registerModel.EmployeeNumber
            };
        }

        public static Register ToRegisterFromRegisterStaffDto(this RegisterStaffDto registerDto)
        {
            return new Register
            {
                Surname = registerDto.Surname,
                OtherNames = registerDto.OtherNames,
                DateOfBirth = DateOnly.Parse(registerDto.DateOfBirth),
                Photo = registerDto.Photo,
                StaffAccessCode = registerDto.StaffAccessCode,
            };
        }
    }
}
