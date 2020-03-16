namespace cojApi.Models {
    public class cojRegionReserveAllot {
        public long id { get; set; }
        public long idRef { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public long itemSort { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string remark { get; set; }
        public long agencyType { get; set; }
        public long cojAgencyId { get; set; }
        public long cojFund { get; set; }
        public long cojBGPlanId { get; set; }
        public long cojWorkplanTypeId { get; set; }
        public long cojBGWorkplanId { get; set; }
        public long cojWorkActivityId { get; set; }
        public long cojWorkActivityItemId { get; set; }
        public long quantityUnit { get; set; }
        public string quantityUnitName { get; set; }
        public double unitPrice { get; set; }
        public double cojRegionReserveAMT { get; set; }
        public double cojRegionReserveAllotQ1 { get; set; }
        public double cojRegionReserveAllotQ2 { get; set; }
        public double cojRegionReserveAllotQ3 { get; set; }
        public double cojRegionReserveAllotQ4 { get; set; }
        public long cojAllotType { get; set; }
    }

    public class cojRegionReserveActivityItem {
        public long id { get; set; }
        public long idRef { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public long cojBGPlanId { get; set; }
        public long cojAgencyId { get; set; }
        public long cojWorkplanTypeId { get; set; }
        public long cojBGWorkplanId { get; set; }
        public long cojWorkActivityId { get; set; }
        public long itemSort { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long cojBudgetType { get; set; }
        public long cojItemType { get; set; }
        public double cojRegionReserveAMT { get; set; }
    }

    public class cojRegionReserveExtra {
        public long id { get; set; }
        public long idRef { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string name { get; set; }
        public long cojAgencyId { get; set; }
        public long cojBGPlanId { get; set; }
        public long cojWorkplanTypeId { get; set; }
        public long cojBGWorkplanId { get; set; }
        public long cojWorkActivityId { get; set; }
        public long cojWorkActivityItemId { get; set; }
        public double cojRegionReserveExtraQ1 { get; set; }
        public double cojRegionReserveExtraQ2 { get; set; }
        public double cojRegionReserveExtraQ3 { get; set; }
        public double cojRegionReserveExtraQ4 { get; set; }
    }

    public class cojRegionAllot {
        public long id { get; set; }
        public long idRef { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public long cojAgencyType { get; set; }
        public long cojAgencyId { get; set; }
        public long cojBGPlanId { get; set; }
        public long cojWorkplanTypeId { get; set; }
        public long cojBGWorkplanId { get; set; }
        public long cojWorkActivityId { get; set; }
        public long cojBudgetType { get; set; }
        public long cojWorkActivityItemId { get; set; }
        public long itemSort { get; set; }
        public string name { get; set; }
        public string cojRegionAllotDate { get; set; }

    }

    public class cojRegionAllotItem {
        public long id { get; set; }
        public long idRef { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public long cojRegionAllotId { get; set; }
        public long itemSort { get; set; }
        public long cojAgencyId { get; set; }
        public string name { get; set; }
        public double cojRegionAllotUnit { get; set; }
        public string cojRegionAllotUnitName { get; set; }
        public double cojRegionAllotUnitPrice { get; set; }
        public double cojRegionAllotAMT { get; set; }

    }

}