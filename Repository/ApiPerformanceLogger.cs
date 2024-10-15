using HRManagementApp.Data;
using HRManagementApp.Dtos;
using HRManagementApp.Interfaces;
using HRManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HRManagementApp.Repository
{
    public class ApiPerformanceLogger : IApiPerformanceLogger
    {
        private readonly DataContext _dbContext;
        public ApiPerformanceLogger(DataContext context)
        {
            _dbContext = context;
        }

        public async Task LogRequestAsync(string requestPath, DateTime requestTime, bool isSuccess)
        {
            var log = new ApiPerformanceLogs
            {
                RequestPath = requestPath,
                RequestTime = requestTime,
                IsSuccessful = isSuccess
            };

            _dbContext.ApiPerformanceLogs.Add(log);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<PerformanceMetricsDto> GetPerformanceMetricsAsync()
        {
            var totalRequests = await _dbContext.ApiPerformanceLogs.CountAsync();
            var successfulRequests = await _dbContext.ApiPerformanceLogs.CountAsync(log => log.IsSuccessful);
            var failedRequests = totalRequests - successfulRequests;

            return new PerformanceMetricsDto
            {
                TotalRequests = totalRequests,
                SuccessfulRequests = successfulRequests,
                FailedRequests = failedRequests
            };
        }
    }
}