namespace cojApi.Models
{
    public class cojUAT
    {
        public long id { get; set; }
        public long idRef { get; set; }
        public long uatNo { get; set; }
        public string uatCode { get; set; }
        public string uatName { get; set; }
        public string uatDate { get; set; }
        public string uatNote { get; set; }
        public bool uatResult { get; set; }
        public string uatTester { get; set; }
        public string cojApp { get; set; }
        public string cojCmd { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }
    

}