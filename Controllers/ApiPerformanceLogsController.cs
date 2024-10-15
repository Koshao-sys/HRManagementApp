using HRManagementApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace HRManagementApp.Controllers
{
    [Route("api")]
    [ApiController]
    public class ApiPerformanceLogsController(IApiPerformanceLogger performanceLogger) : ControllerBase
    {
        private readonly IApiPerformanceLogger _performanceLogger = performanceLogger;

        [HttpGet("logs")]
        public async Task<IActionResult> GetAllPerfomanceLogs()
        {
            if (!ModelState.IsValid)
            {
                await _performanceLogger.LogRequestAsync("/api/logs", DateTime.Now, false);
                return BadRequest(ModelState);
            }

            try
            {
                var metrics = await _performanceLogger.GetPerformanceMetricsAsync();
                return Ok(metrics);

            }
            catch (Exception ex)
            {
                await _performanceLogger.LogRequestAsync("/api/logs", DateTime.Now, false);
                return StatusCode(500, ex.Message.ToString());
            }
        }
    }
}
