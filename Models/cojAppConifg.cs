namespace cojApi.Models {

    public class cojAppConfig {
        public long id { get; set; }
        public long idRef { get; set; }
        public string configCode { get; set; }
        public string configName { get; set; }
        public string configValue { get; set; }
        public string remark { get; set; }
        public long configType { get; set; }
        public string configRight { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public long status { get; set; }
        public long userCreate { get; set; }
        public long userUpdate { get; set; }
        public long userAudit { get; set; }
        public string userAuditDate { get; set; }
        public long userApprove { get; set; }
        public string userApproveDate { get; set; }
    }

}