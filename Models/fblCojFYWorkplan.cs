using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cojApi.Models {
    public class fblCojFYWorkplanType {
        [Key, ColumnAttribute (Order = 0)]
        public long fy { get; set; }

        [Key, ColumnAttribute (Order = 1)]
        public long cojWorkplanTypeId { get; set; }
        public string cojWorkplanTypeName { get; set; }
        public double cojBGPlanSumA { get; set; }
        public double cojBGPlanSumB { get; set; }
        public double cojBGPlanSumC { get; set; }
        public double cojBGPlanSumAMT { get; set; }

    }

    public class fblCojFYWorkplan {
        [Key, ColumnAttribute (Order = 0)]
        public long fy { get; set; }

        [Key, ColumnAttribute (Order = 1)]
        public long cojWorkplanTypeId { get; set; }

        [Key, ColumnAttribute (Order = 2)]
        public long cojBGWorkplanId { get; set; }
        public string name { get; set; }
        public double cojBGPlanSumA { get; set; }
        public double cojBGPlanSumB { get; set; }
        public double cojBGPlanSumC { get; set; }
        public double cojBGPlanSumAMT { get; set; }

    }

    public class fblCojFYWorkplanActivity {
        [Key, ColumnAttribute (Order = 0)]
        public long fy { get; set; }

        [Key, ColumnAttribute (Order = 1)]
        public long cojWorkplanTypeId { get; set; }

        [Key, ColumnAttribute (Order = 2)]
        public long cojBGWorkplanId { get; set; }

        [Key, ColumnAttribute (Order = 3)]
        public long cojWorkActivityId { get; set; }
        public string cojWorkActivityName { get; set; }
        public double cojBGPlanSumA { get; set; }
        public double cojBGPlanSumB { get; set; }
        public double cojBGPlanSumC { get; set; }
        public double cojBGPlanSumAMT { get; set; }

    }

    public class fblCojFYWorkplanActivityBGType {
        [Key, ColumnAttribute (Order = 0)]
        public long fy { get; set; }

        [Key, ColumnAttribute (Order = 1)]
        public long cojWorkplanTypeId { get; set; }

        [Key, ColumnAttribute (Order = 2)]
        public long cojBGWorkplanId { get; set; }

        [Key, ColumnAttribute (Order = 3)]
        public long cojWorkActivityId { get; set; }

        [Key, ColumnAttribute (Order = 4)]
        public long cojBudgetTypeId { get; set; }
        public string cojBudgetTypeName { get; set; }
        public double cojBGPlanSumA { get; set; }
        public double cojBGPlanSumB { get; set; }
        public double cojBGPlanSumC { get; set; }
        public double cojBGPlanSumAMT { get; set; }

    }

    public class fblCojFYWorkplanActivityBGTypeFund {
        [Key, ColumnAttribute (Order = 0)]
        public long fy { get; set; }

        [Key, ColumnAttribute (Order = 1)]
        public long cojWorkplanTypeId { get; set; }

        [Key, ColumnAttribute (Order = 2)]
        public long cojBGWorkplanId { get; set; }

        [Key, ColumnAttribute (Order = 3)]
        public long cojWorkActivityId { get; set; }

        [Key, ColumnAttribute (Order = 4)]
        public long cojBudgetTypeId { get; set; }

        [Key, ColumnAttribute (Order = 5)]
        public long cojFund { get; set; }
        public string cojFundName { get; set; }
        public double cojBGPlanSumA { get; set; }
        public double cojBGPlanSumB { get; set; }
        public double cojBGPlanSumC { get; set; }
        public double cojBGPlanSumAMT { get; set; }

    }

    public class fblCojFYWorkplanBGTypeFundB {
        [Key, ColumnAttribute (Order = 0)]
        public long fy { get; set; }
        [Key, ColumnAttribute (Order = 1)]
        public long cojWorkplanTypeId { get; set; }
        [Key, ColumnAttribute (Order = 2)]
        public long cojBGWorkplanId { get; set; }
        [Key, ColumnAttribute (Order = 3)]
        public int cojBudgetTypeId { get; set; }
        public string cojBudgetTypeName { get; set; }
        public double cojBGPlanFund49 { get; set; }
        public double cojBGPlanFund50 { get; set; }
        public double cojBGPlanFund51 { get; set; }
        public double cojBGPlanFund52 { get; set; }
    }
    public class fblCojFYWorkplanActivityBGTypeFundB {
        [Key, ColumnAttribute (Order = 0)]
        public long fy { get; set; }
        [Key, ColumnAttribute (Order = 1)]
        public long cojWorkplanTypeId { get; set; }
        [Key, ColumnAttribute (Order = 2)]
        public long cojBGWorkplanId { get; set; }
        [Key, ColumnAttribute (Order = 3)]
        public long cojWorkActivityId { get; set; }
        [Key, ColumnAttribute (Order = 4)]
        public int cojBudgetTypeId { get; set; }
        public string cojBudgetTypeName { get; set; }
        public double cojBGPlanFund49 { get; set; }
        public double cojBGPlanFund50 { get; set; }
        public double cojBGPlanFund51 { get; set; }
        public double cojBGPlanFund52 { get; set; }
    }
}