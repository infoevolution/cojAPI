using System.ComponentModel.DataAnnotations;

namespace cojApi.Models
{
    public class paramCojFYTransferAllotQuater
    {
        public long fy { get; set;}
        public long quater { get; set; }
        public long allotType { get; set;}
        
    }
    public class spParam {
        public string data {get; set;}
    }

    public class spRet{
        [Key]
        public int status { get; set;}
        public string msg { get; set; }
        
    }
    public class paramCojStg
    {
        public long fy { get; set;}
        public long cojStg { get; set; }   
    }
    public class paramCojBGPlanWork
    {
        public long fy { get; set;}
        public long cojBGWorkplan { get; set; }
        public long cojBudgetType { get; set;}
        
    }

    public class paramCojBGPlanWorkFund
    {
        public long fy { get; set;}
        public long cojBGWorkplan { get; set; }
        public long cojFund { get; set;}
        
    }
    public class paramCojBGPlanQuarter
    {
        public int fy { get; set;}
        public long cojBGWorkplanId { get; set; }
        public long cojWorkActivityId { get; set;}
        public long cojBudgetTypeId { get; set;}
        
    }

}