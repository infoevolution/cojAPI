namespace cojApi.Models
{
    public class cojLog
    {
        public long id { get; set; }
        public string appModule { get; set; }
        public string message { get; set; }
        public string payload { get; set; }
        public string logDate { get; set; }
        public string clientIP { get; set; }
    }
}