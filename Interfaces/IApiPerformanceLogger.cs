using HRManagementApp.Dtos;
using HRManagementApp.Models;

namespace HRManagementApp.Interfaces
{
    public interface IApiPerformanceLogger
    {
        Task LogRequestAsync(string requestPath, DateTime requestTime, bool isSuccess);
        Task<PerformanceMetricsDto> GetPerformanceMetricsAsync();
    }
}