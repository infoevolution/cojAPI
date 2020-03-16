namespace cojApi.Models
{
    public class cojMasterData
    {
        public long id { get; set; }
        public string code { get; set; }
        // public string label { get; set; }
        public string name { get; set; }
        public long idRef { get; set; }
        public long itemSort { get; set; }
        public long idDataCategory { get; set; }
        public long idParent { get; set; }
        public string createDate { get; set; }
        public string updateDate { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public long status { get; set; }
        public long userCreate { get; set; }
        public long userUpdate { get; set; }
        public long userAudit { get; set; }
        public string userAuditDate { get; set; }
        public long userApprove { get; set; }
        public string userApproveDate { get; set; }
        public string remark { get; set; }
        public string formData { get; set; }
        public string docData { get; set; }

    }

    public class cojDataCategory
    {
        public long id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public long idRef { get; set; }
        public long itemSort { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string createDate { get; set; }
        public string updateDate { get; set; }
        public long status { get; set; }
        public long userCreate { get; set; }
        public long userUpdate { get; set; }
        public string remark { get; set; }
    }
    public class cojApp
    {
         public long id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
    }
    public class cojCmd
    {
        public long id { get; set; }
        public long cojApp { get; set; }
        public string code { get; set; }
        public string name { get; set; }
    }
}
