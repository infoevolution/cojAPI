namespace cojApi.Models
{
    public class cojData
    {
        public long id { get; set;}
        public string key { get; set; }
        public string label { get; set; }
        public long order { get; set;}
        public string value { get; set;}
        public bool required { get; set;}
        public string controlType { get; set;}
        public bool show { get; set;}
        public bool disabled { get; set;}
        public string type { get; set; }
        public string options { get; set; }
        public string remark { get; set; }
        public long dataCategory  { get; set; }
        public long idRef { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }

    }
}
