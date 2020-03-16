using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cojApi.Models 
{
    public class cojBGPlanWork {
        [Key, ColumnAttribute (Order = 0)]
        public long fy { get; set; }
        public long cojStgPlanId { get; set; }
        public long cojStgId { get; set; }
        public long cojWorkplanTypeId { get; set; }
        [Key, ColumnAttribute (Order = 1)]
        public long cojBGWorkplanId { get; set; }
        public string name { get; set; }
        public double budgetAMT { get; set; }
    }

    public class cojBGPlanWorkActivity {
        [Key, ColumnAttribute (Order = 0)]
        public long fy { get; set; }
        public long cojStgPlanId { get; set; }
        public long cojStgId { get; set; }
        public long cojWorkplanTypeId { get; set; }
        [Key, ColumnAttribute (Order = 1)]
        public long cojBGWorkplanId { get; set; }
        [Key, ColumnAttribute (Order = 2)]
        public long cojWorkActivityId { get; set; }
        public string name { get; set; }
        public double budgetAMT { get; set; }
    }

    public class cojBGPlanWorkActivityBGType {
        [Key, ColumnAttribute (Order = 0)]
        public long fy { get; set; }
        public long cojStgPlanId { get; set; }
        public long cojStgId { get; set; }
        public long cojWorkplanTypeId { get; set; }
        [Key, ColumnAttribute (Order = 1)]
        public long cojBGWorkplanId { get; set; }
        [Key, ColumnAttribute (Order = 2)]
        public long cojWorkActivityId { get; set; }
        [Key, ColumnAttribute (Order = 3)]
        public long cojBudgetType { get; set; }
        public string name { get; set; }
        public double budgetAMT { get; set; }
    }

    public class cojBGPlanWorkActivityBGTypeFund {
        [Key, ColumnAttribute (Order = 0)]
        public long fy { get; set; }
        public long cojStgPlanId { get; set; }
        public long cojStgId { get; set; }
        public long cojWorkplanTypeId { get; set; }
        [Key, ColumnAttribute (Order = 1)]
        public long cojBGWorkplanId { get; set; }
        [Key, ColumnAttribute (Order = 2)]
        public long cojWorkActivityId { get; set; }
        [Key, ColumnAttribute (Order = 3)]
        public long cojBudgetType { get; set; }
        [Key, ColumnAttribute (Order = 4)]
        public long cojFund { get; set; }
        public string name { get; set; }
        public double budgetAMT { get; set; }
    }


    public class cojBGPlanWorkActivityFund {
        [Key, ColumnAttribute (Order = 0)]
        public long fy { get; set; }
        public long cojStgPlanId { get; set; }
        public long cojStgId { get; set; }
        public long cojWorkplanTypeId { get; set; }
        [Key, ColumnAttribute (Order = 1)]
        public long cojBGWorkplanId { get; set; }
        [Key, ColumnAttribute (Order = 2)]
        public long cojWorkActivityId { get; set; }
        [Key, ColumnAttribute (Order = 3)]
        public long cojFund { get; set; }
        public string name { get; set; }
        public double budgetAMT { get; set; }
    }
}