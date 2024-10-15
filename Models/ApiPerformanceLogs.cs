namespace HRManagementApp.Models
{
    public class ApiPerformanceLogs
    {
        public int Id { get; set; }
        public string RequestPath { get; set; }
        public DateTime RequestTime { get; set; }
        public bool IsSuccessful { get; set; }
    }
}
