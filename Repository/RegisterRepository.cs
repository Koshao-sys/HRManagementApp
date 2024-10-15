using HRManagementApp.Data;
using HRManagementApp.Dtos;
using HRManagementApp.Interfaces;
using HRManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HRManagementApp.Repository
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly DataContext _context;
        public RegisterRepository(DataContext context) 
        {
            _context = context;
        }

        public async Task<List<Register>> GetAllStaffAsync() => await _context.Registers.ToListAsync();

        public async Task<Register?> GetStaffByIdAsync(int id) => await _context.Registers.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Register> RegisterStaffAsync(Register registerModel)
        {
            registerModel.EmployeeNumber = Guid.NewGuid().ToString();
            await _context.Registers.AddAsync(registerModel);
            await _context.SaveChangesAsync();
            return registerModel;
        }

        public async Task<Register?> UpdateStaffRegisterAsync(int id, UpdateStaffRegisterDto record)
        {
            var registerModel = await _context.Registers.FirstOrDefaultAsync(x => x.Id == id);
            
            if (registerModel == null)
                return null;

            registerModel.DateOfBirth = DateOnly.Parse(record.DateOfBirth);
            registerModel.Photo = record.Photo;
            await _context.SaveChangesAsync();

            return registerModel;
        }

        public async Task<Register?> DeleteStaffAsync(int id)
        {
            var staffModel = await _context.Registers.FirstOrDefaultAsync(x => x.Id == id);

            if (staffModel == null)
            {
                return null;
            }

            _context.Registers.Remove(staffModel);
            await _context.SaveChangesAsync();
            return staffModel;
        }
    }
}
