using System;
namespace cojApi.Models
{ 
    public class cojIntegration {
        public long id { get; set; }
        public long idRef { get; set; }
        public string name { get; set; }
        public long cojBGPlanId { get; set; }
        public long cojWorkplanTypeId { get; set; }
        public long cojBGWorkplanId { get; set; }
        public long cojWorkActivityId { get; set; }
        public long cojWorkActivityItemId { get; set; }
        public long cojBudgetType { get; set; }
        public long cojAgencyId { get; set; }
        public double cojBGPlanAMT { get; set; }
        public double cojBGAllotAMT { get; set; }
        public double cojBGApproveAMT { get; set; }
        public double cojBGTransferAMT { get; set; }
        public string remark {get; set;}
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

public class cojIntegrationAllot {
        public long id { get; set; }
        public long idRef { get; set; }
        public long itemSort { get; set; }
        public string name { get; set; }
        public long cojIntegrationId { get; set; }
        public string cojIntegrationAllotDate { get; set; }
        public double cojBGTransferQ1 { get; set; }
        public double cojBGTransferQ2 { get; set; }
        public double cojBGTransferQ3 { get; set; }
        public double cojBGTransferQ4 { get; set; }
        public double cojBGTransferAMT { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

public class cojIntegrationAllotItem {
        public long id { get; set; }
        public long idRef { get; set; }
        public long itemSort { get; set; }
        public string name { get; set; }
        public long cojIntegrationId { get; set; }
        public long cojIntegrationAllotId { get; set; }
        public long cojAgencyId { get; set; }
        public double cojBGTransferAMT { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }
}
    