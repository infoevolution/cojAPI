using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cojApi.Models {
    public class spCojFYWorkplanType {
        [Key]
        public long cojWorkplanTypeId { get; set; }
        public long fy { get; set; }
        public string cojWorkplanTypeName { get; set; }
        public double cojBGPlanSumA { get; set; }
        public double cojBGPlanSumB { get; set; }
        public double cojBGPlanSumC { get; set; }
        public double cojBGPlanSumAMT { get; set; }
        public double cojBGPlanAllotQ1 { get; set; }
        public double cojBGPlanAllotQ2 { get; set; }
        public double cojBGPlanAllotQ3 { get; set; }
        public double cojBGPlanAllotQ4 { get; set; }
        public double cojBGPlanAllotSumAMT { get; set; }
        public double cojBGExtraAllotQ1 { get; set; }
        public double cojBGExtraAllotQ2 { get; set; }
        public double cojBGExtraAllotQ3 { get; set; }
        public double cojBGExtraAllotQ4 { get; set; }
        public double cojBGExtraAllotSumAMT { get; set; }
    }

    public class spCojFYWorkplan {

        [Key, ColumnAttribute (Order = 0)]
        public long cojWorkplanTypeId { get; set; }

        [Key, ColumnAttribute (Order = 1)]
        public long cojBGWorkplanId { get; set; }
        public string cojWorkplanTypeName { get; set; }
        public long fy { get; set; }
        public string cojBGWorkplanName { get; set; }
        public double cojBGPlanSumA { get; set; }
        public double cojBGPlanSumB { get; set; }
        public double cojBGPlanSumC { get; set; }
        public double cojBGPlanSumAMT { get; set; }
        public double cojBGPlanAllotQ1 { get; set; }
        public double cojBGPlanAllotQ2 { get; set; }
        public double cojBGPlanAllotQ3 { get; set; }
        public double cojBGPlanAllotQ4 { get; set; }
        public double cojBGPlanAllotSumAMT { get; set; }
        public double cojBGExtraAllotQ1 { get; set; }
        public double cojBGExtraAllotQ2 { get; set; }
        public double cojBGExtraAllotQ3 { get; set; }
        public double cojBGExtraAllotQ4 { get; set; }
        public double cojBGExtraAllotSumAMT { get; set; }
    }

    public class spCojFYWorkplanFund {

        [Key, ColumnAttribute (Order = 0)]
        public long cojWorkplanTypeId { get; set; }

        [Key, ColumnAttribute (Order = 1)]
        public long cojBGWorkplanId { get; set; }

        [Key, ColumnAttribute (Order = 2)]
        public long cojFund { get; set; }
        public string cojWorkplanTypeName { get; set; }
        public long fy { get; set; }
        public string cojBGWorkplanName { get; set; }
        public string cojFundName { get; set; }
        public double cojBGPlanSumA { get; set; }
        public double cojBGPlanSumB { get; set; }
        public double cojBGPlanSumC { get; set; }
        public double cojBGPlanSumAMT { get; set; }
    }

    public class spCojFYWorkplanActivity {

        [Key, ColumnAttribute (Order = 0)]
        public long cojWorkplanTypeId { get; set; }

        [Key, ColumnAttribute (Order = 1)]
        public long cojBGWorkplanId { get; set; }

        [Key, ColumnAttribute (Order = 2)]
        public long cojWorkActivityId { get; set; }
        public string name { get; set; }
        public long fy { get; set; }
        public double cojBGPlanSumA { get; set; }
        public double cojBGPlanSumB { get; set; }
        public double cojBGPlanSumC { get; set; }
        public double cojBGPlanSumAMT { get; set; }

        public double cojBGPlanAllotQ1 { get; set; }
        public double cojBGPlanAllotQ2 { get; set; }
        public double cojBGPlanAllotQ3 { get; set; }
        public double cojBGPlanAllotQ4 { get; set; }
        public double cojBGPlanAllotSumAMT { get; set; }
        public double cojBGExtraAllotQ1 { get; set; }
        public double cojBGExtraAllotQ2 { get; set; }
        public double cojBGExtraAllotQ3 { get; set; }
        public double cojBGExtraAllotQ4 { get; set; }
        public double cojBGExtraAllotSumAMT { get; set; }
    }

    public class spCojFYWorkplanActivityFund {

        [Key, ColumnAttribute (Order = 0)]
        public long cojWorkplanTypeId { get; set; }

        [Key, ColumnAttribute (Order = 1)]
        public long cojBGWorkplanId { get; set; }

        [Key, ColumnAttribute (Order = 2)]
        public long cojWorkActivityId { get; set; }

        [Key, ColumnAttribute (Order = 3)]
        public long fy { get; set; }
        public long cojFund { get; set; }
        public string name { get; set; }
        public string cojFundName { get; set; }
        public double cojBGPlanSumA { get; set; }
        public double cojBGPlanSumB { get; set; }
        public double cojBGPlanSumC { get; set; }
        public double cojBGPlanSumAMT { get; set; }
        public double cojBGPlanAllotQ1 { get; set; }
        public double cojBGPlanAllotQ2 { get; set; }
        public double cojBGPlanAllotQ3 { get; set; }
        public double cojBGPlanAllotQ4 { get; set; }
        public double cojBGPlanAllotSumAMT { get; set; }
        public double cojBGExtraAllotQ1 { get; set; }
        public double cojBGExtraAllotQ2 { get; set; }
        public double cojBGExtraAllotQ3 { get; set; }
        public double cojBGExtraAllotQ4 { get; set; }
        public double cojBGExtraAllotSumAMT { get; set; }
        public double cojBGPlanAllotAQ1 { get; set; }
        public double cojBGPlanAllotAQ2 { get; set; }
        public double cojBGPlanAllotAQ3 { get; set; }
        public double cojBGPlanAllotAQ4 { get; set; }
        public double cojBGPlanAllotAsumAMT  { get; set; }
        public double cojBGPlanAllotBQ1 { get; set; }
        public double cojBGPlanAllotBQ2 { get; set; }
        public double cojBGPlanAllotBQ3 { get; set; }
        public double cojBGPlanAllotBQ4 { get; set; }
        public double cojBGPlanAllotBsumAMT  { get; set; }
        public double cojBGPlanAllotCQ1 { get; set; }
        public double cojBGPlanAllotCQ2 { get; set; }
        public double cojBGPlanAllotCQ3 { get; set; }
        public double cojBGPlanAllotCQ4 { get; set; }
        public double cojBGPlanAllotCsumAMT  { get; set; }
        public double cojBGExtraAllotAQ1 { get; set; }
        public double cojBGExtraAllotAQ2 { get; set; }
        public double cojBGExtraAllotAQ3 { get; set; }
        public double cojBGExtraAllotAQ4 { get; set; }
        public double cojBGExtraAllotAsumAMT  { get; set; }
        public double cojBGExtraAllotBQ1 { get; set; }
        public double cojBGExtraAllotBQ2 { get; set; }
        public double cojBGExtraAllotBQ3 { get; set; }
        public double cojBGExtraAllotBQ4 { get; set; }
        public double cojBGExtraAllotBsumAMT  { get; set; }
        public double cojBGExtraAllotCQ1 { get; set; }
        public double cojBGExtraAllotCQ2 { get; set; }
        public double cojBGExtraAllotCQ3 { get; set; }
        public double cojBGExtraAllotCQ4 { get; set; }
        public double cojBGExtraAllotCsumAMT  { get; set; }
    }

   public class spCojFYWorkplanActivityBGType {

        [Key, ColumnAttribute (Order = 0)]
        public long cojWorkplanTypeId { get; set; }

        [Key, ColumnAttribute (Order = 1)]
        public long cojBGWorkplanId { get; set; }

        [Key, ColumnAttribute (Order = 2)]
        public long cojWorkActivityId { get; set; }

        [Key, ColumnAttribute (Order = 3)]
        public long fy { get; set; }

        [Key, ColumnAttribute (Order = 4)]
        public long cojBudgetType { get; set; }
        public string name { get; set; }
        public string cojBudgetTypeName { get; set; }
        public double cojBGPlanSumA { get; set; }
        public double cojBGPlanSumB { get; set; }
        public double cojBGPlanSumC { get; set; }
        public double cojBGPlanSumAMT { get; set; }
        public double cojBGPlanAllotQ1 { get; set; }
        public double cojBGPlanAllotQ2 { get; set; }
        public double cojBGPlanAllotQ3 { get; set; }
        public double cojBGPlanAllotQ4 { get; set; }
        public double cojBGPlanAllotSumAMT { get; set; }
        public double cojBGExtraAllotQ1 { get; set; }
        public double cojBGExtraAllotQ2 { get; set; }
        public double cojBGExtraAllotQ3 { get; set; }
        public double cojBGExtraAllotQ4 { get; set; }
        public double cojBGExtraAllotSumAMT { get; set; }
        public double cojBGPlanAllotAQ1 { get; set; }
        public double cojBGPlanAllotAQ2 { get; set; }
        public double cojBGPlanAllotAQ3 { get; set; }
        public double cojBGPlanAllotAQ4 { get; set; }
        public double cojBGPlanAllotAsumAMT  { get; set; }
        public double cojBGPlanAllotBQ1 { get; set; }
        public double cojBGPlanAllotBQ2 { get; set; }
        public double cojBGPlanAllotBQ3 { get; set; }
        public double cojBGPlanAllotBQ4 { get; set; }
        public double cojBGPlanAllotBsumAMT  { get; set; }
        public double cojBGPlanAllotCQ1 { get; set; }
        public double cojBGPlanAllotCQ2 { get; set; }
        public double cojBGPlanAllotCQ3 { get; set; }
        public double cojBGPlanAllotCQ4 { get; set; }
        public double cojBGPlanAllotCsumAMT  { get; set; }
        public double cojBGExtraAllotAQ1 { get; set; }
        public double cojBGExtraAllotAQ2 { get; set; }
        public double cojBGExtraAllotAQ3 { get; set; }
        public double cojBGExtraAllotAQ4 { get; set; }
        public double cojBGExtraAllotAsumAMT  { get; set; }
        public double cojBGExtraAllotBQ1 { get; set; }
        public double cojBGExtraAllotBQ2 { get; set; }
        public double cojBGExtraAllotBQ3 { get; set; }
        public double cojBGExtraAllotBQ4 { get; set; }
        public double cojBGExtraAllotBsumAMT  { get; set; }
        public double cojBGExtraAllotCQ1 { get; set; }
        public double cojBGExtraAllotCQ2 { get; set; }
        public double cojBGExtraAllotCQ3 { get; set; }
        public double cojBGExtraAllotCQ4 { get; set; }
        public double cojBGExtraAllotCsumAMT  { get; set; }
    }

}