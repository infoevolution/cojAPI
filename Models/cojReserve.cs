namespace cojApi.Models
{
     public class cojReserve
    {
        public long id { get; set; }
        public long idRef { get; set; }
        public long itemSort { get; set; }
        public long cojAgencyId { get; set; }
        public long cojPeriod { get; set; }
        public long cojFund { get; set; }
        public long cojBGPlanId { get; set; }
        public long cojWorkplanTypeId { get; set; }
        public long cojBGWorkplanId { get; set; }
        public long cojWorkActivityId { get; set; }
        public string cojBGWorkplanName { get; set; }
        public long cojStgPlanId { get; set; }
        public long cojStgId { get; set; }
        public long cojReserveNo { get; set; }
        public string cojReserveDate { get; set; }
        public string cojReserveDocNo { get; set; }
        public double cojReserveSumA { get; set; }
        public double cojReserveSumB { get; set; }
        public double cojReserveSumC { get; set; }
        public double cojReserveSumAMT { get; set; }
        public double cojReserveFeeB { get; set; }
        public double cojReserveFeeC { get; set; }
        public double cojReserveFeeAMT { get; set; }
        public string cojReserveTransferDocNo { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }
}