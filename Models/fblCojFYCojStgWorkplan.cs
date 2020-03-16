using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cojApi.Models
{

    public class fblCojFYCojStg
    {
        [Key, ColumnAttribute (Order = 0)]
        public long fy { get; set;}
        [Key, ColumnAttribute (Order = 1)]
        public long cojStgId { get; set;}
        public string code { get; set;}
        public string nameEn { get; set;}
        public string cojStgName { get; set;}
        public double cojBGPlanSumA { get; set;}
        public double cojBGPlanSumB { get; set;}
        public double cojBGPlanSumC { get; set;}
        public double cojBGPlanSumAMT { get; set;}

    }
    public class fblCojFYCojStgWorkplanType
    {
        [Key, ColumnAttribute (Order = 0)]
        public long fy { get; set;}
        [Key, ColumnAttribute (Order = 1)]
        public long cojStgId { get; set;}
        [Key, ColumnAttribute (Order = 2)]
        public long cojWorkplanTypeId { get; set;}
        public string cojWorkplanTypeName { get; set;}
        public double cojBGPlanSumA { get; set;}
        public double cojBGPlanSumB { get; set;}
        public double cojBGPlanSumC { get; set;}
        public double cojBGPlanSumAMT { get; set;}

    }

    public class fblCojFYCojStgWorkplan
    {
        [Key, ColumnAttribute (Order = 0)]
        public long fy { get; set;}
        [Key, ColumnAttribute (Order = 1)]
        public long cojStgId { get; set;}
        [Key, ColumnAttribute (Order = 2)]
        public long cojWorkplanTypeId { get; set;}
        [Key, ColumnAttribute (Order = 3)]
        public long cojBGWorkplanId { get; set;}
        public string name { get; set;}
        public double cojBGPlanSumA { get; set;}
        public double cojBGPlanSumB { get; set;}
        public double cojBGPlanSumC { get; set;}
        public double cojBGPlanSumAMT { get; set;}

    }

    public class fblCojFYCojStgWorkplanActivity
    {
        [Key, ColumnAttribute (Order = 0)]
        public long fy { get; set;}
        [Key, ColumnAttribute (Order = 1)]
        public long cojStgId { get; set;}
        [Key, ColumnAttribute (Order = 2)]
        public long cojWorkplanTypeId { get; set;}
        [Key, ColumnAttribute (Order = 3)]
        public long cojBGWorkplanId { get; set;}
        [Key, ColumnAttribute (Order = 4)]
        public long cojWorkActivityId { get; set;}
        public string cojWorkActivityName { get; set;}
        public double cojBGPlanSumA { get; set;}
        public double cojBGPlanSumB { get; set;}
        public double cojBGPlanSumC { get; set;}
        public double cojBGPlanSumAMT { get; set;}

    }

    public class fblCojFYCojStgWorkplanActivityBGType
    {
        [Key, ColumnAttribute (Order = 0)]
        public long fy { get; set;}
        [Key, ColumnAttribute (Order = 1)]
        public long cojStgId { get; set;}
        [Key, ColumnAttribute (Order = 2)]
        public long cojWorkplanTypeId { get; set;}
        [Key, ColumnAttribute (Order = 3)]
        public long cojBGWorkplanId { get; set;}
        [Key, ColumnAttribute (Order = 4)]
        public long cojWorkActivityId { get; set;}
        [Key, ColumnAttribute (Order = 5)]
        public      long cojBudgetTypeId { get; set;}
        public string cojBudgetTypeName { get; set;}
        public double cojBGPlanSumA { get; set;}
        public double cojBGPlanSumB { get; set;}
        public double cojBGPlanSumC { get; set;}
        public double cojBGPlanSumAMT { get; set;}

    }

        public class fblCojFYCojStgWorkplanActivityBGTypeFund
    {
        [Key, ColumnAttribute (Order = 0)]
        public long fy { get; set;}
        [Key, ColumnAttribute (Order = 1)]
    public long cojStgId { get; set;}
        [Key, ColumnAttribute (Order = 2)]
        public long cojWorkplanTypeId { get; set;}
        [Key, ColumnAttribute (Order = 3)]
        public long cojBGWorkplanId { get; set;}
        [Key, ColumnAttribute (Order = 4)]
        public long cojWorkActivityId { get; set;}
        [Key, ColumnAttribute (Order = 5)]
        public long cojBudgetTypeId { get; set;}
        [Key, ColumnAttribute (Order = 6)]
        public long cojFund { get; set;}
        public string cojFundName { get; set;}
        public double cojBGPlanSumA { get; set;}
        public double cojBGPlanSumB { get; set;}
        public double cojBGPlanSumC { get; set;}
        public double cojBGPlanSumAMT { get; set;}

    }
}