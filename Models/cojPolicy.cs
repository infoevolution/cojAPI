namespace cojApi.Models
{

    public class cojPolicy
    {
        public long id { get; set; }
        public long idRef { get; set; }
        public string name { get; set; }
        public bool isActive {get; set;}
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

    public class cojPolicyItem
    {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long cojPolicyId { get; set; }
        public long parentId { get; set; }
        public long level { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }
}