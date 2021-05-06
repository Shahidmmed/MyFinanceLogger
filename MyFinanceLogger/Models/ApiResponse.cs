namespace MyFinanceLogger.Models
{
    public class ApiResponse
    {
        public string Message { get; set; }
        public bool IsSuccessful { get; set; }
        public dynamic Data { get; set; }
    }
}