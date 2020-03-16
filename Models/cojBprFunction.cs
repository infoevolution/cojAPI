namespace cojApi.Models
{
    public class cojBprFunction
    {
        public long id { get; set;}
        public long idRef { get; set; }
        public long itemSort { get; set; }
        public string code { get; set;}
        public string name { get; set;}
        public long idParent { get; set;}
        public string description { get; set;}
        public string url { get; set;}
        public long sort { get; set; }    
        public string startDate { get; set;}
        public string endDate { get; set; }
    }
}