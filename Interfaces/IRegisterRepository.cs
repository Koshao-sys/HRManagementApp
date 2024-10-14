using HRManagementApp.Dtos;
using HRManagementApp.Models;

namespace HRManagementApp.Interfaces
{
    public interface IRegisterRepository
    {
        Task<List<Register>> GetAllStaffAsync();
        Task<Register?> GetStaffByIdAsync(int id);
        Task<Register> RegisterStaffAsync(Register registerModel);
        Task<Register?> UpdateStaffRegisterAsync(int id, UpdateStaffRegisterDto record);
        Task<Register?> DeleteStaffAsync(int id);
    }
}
