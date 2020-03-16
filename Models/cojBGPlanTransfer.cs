using System;
namespace cojApi.Models
{ 
    public class cojBGPlanTransferAllot {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long cojBGPlanId { get; set; }
        public long cojWorkplanTypeId { get; set; }
        public long cojBGWorkplanId { get; set; }
        public long cojWorkActivityId { get; set; }
         public long cojBudgetType { get; set; }
         public long cojAgencyType { get; set; }
         public long cojAgencyId { get; set; }
        public double cojBGPlanQ1 { get; set; }
        public double cojBGPlanQ2 { get; set; }
        public double cojBGPlanQ3 { get; set; }
        public double cojBGPlanQ4 { get; set; }

        public double cojBGExtraQ1 { get; set; }
        public double cojBGExtraQ2 { get; set; }
        public double cojBGExtraQ3 { get; set; }
        public double cojBGExtraQ4 { get; set; }
        public bool isRegionReserve { get; set; }
        public string remark { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

}
    