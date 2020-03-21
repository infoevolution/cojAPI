using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cojApi.Models {
    public class fblCojBGPlanQuarter {
        public long id { get; set; }

        [Key, ColumnAttribute (Order = 0)]
        public long idRef { get; set; }
        public long code { get; set; }
        public string name { get; set; }
        public int fy { get; set; }
        public long cojFund { get; set; }
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
        public double cojBGPlanAMT { get; set; }
        [Key, ColumnAttribute (Order = 1)]
        public bool isRegionReserve { get; set; }
        public long procumentAgencyId { get; set; }
        public long disbursementAgencyId { get; set; }
        public string coBudgetAgencys { get; set; }
        public string remark { get; set; }
        public long idPlan { get; set; }
        [Key, ColumnAttribute (Order = 2)]
        public long idRefPlan { get; set; }
        public double cojBGPlanAllotQ1 { get; set; }
        public double cojBGPlanAllotQ2 { get; set; }
        public double cojBGPlanAllotQ3 { get; set; }
        public double cojBGPlanAllotQ4 { get; set; }
        public double cojBGExtraAllotQ1 { get; set; }
        public double cojBGExtraAllotQ2 { get; set; }
        public double cojBGExtraAllotQ3 { get; set; }
        public double cojBGExtraAllotQ4 { get; set; }
        public double cojBGPlanAllotAMT { get; set; }
        public double itemSort { get; set; }

    }

}