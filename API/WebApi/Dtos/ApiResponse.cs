namespace ExtremeClassified.WebApi.Dtos
{
    /// <summary>
    /// Author: Abrar Ahmad
    /// Response from any api
    /// </summary>
    public class ApiResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public object ResponseData { get; set; }
    }
}