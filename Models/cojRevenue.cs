namespace cojApi.Models
{

    public class cojRevenue
    {
        public long id { get; set; }
        public long idRef { get; set; }
        public long itemSort { get; set; }
        public string cojDocNo { get; set; }
        public string cojDocDate { get; set; }
        public string cojRevenueFromDate { get; set; }
        public string cojRevenueToDate { get; set; }
        public double cojRevenueAMT { get; set; }
        public double cojRevenueOperationAMT { get; set; }
        public double cojRevenueInvestAMT { get; set; }
        public long cojFund { get; set; }
        public long cojPeriod { get; set; }
        public long cojRevenueAllotNo { get; set; }
        public double cojRevenueAllotAMT { get; set; }
        public double cojRevenueAllotOperation { get; set; }        
        public double cojRevenueAllotInvest { get; set; }
        public double cojRevenueBalanceOperation { get; set; }
        public double cojRevenueBalanceInvest { get; set; }
        public double cojRevenueBalanceAMT { get; set; }
        public double cojRevenueNetOperation { get; set; }
        public double cojRevenueNetInvest { get; set; }
        public double cojRevenueNetAMT { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

    public class cojRevenueAllot
    {
        public long id { get; set; }
        public long idRef { get; set; }
        public long cojFund { get; set; }
        public long cojPeriod { get; set; }
        public long cojWorkplanTypeId { get; set; }
        public long cojBudgetType { get; set; }
        public long cojBGWorkplanId { get; set; }
        public long cojBGWorkplanActivityId { get; set; }
        public long cojAllotNo { get; set; }
        public long cojAllot { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }
    

}