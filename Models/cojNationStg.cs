using System.Collections.Generic;

namespace cojApi.Models
{

    public class cojNationPlan
    {
        public long id { get; set; }
        public long idRef { get; set; }
        public string name { get; set; }
        public string cojNationPlanStartDate { get; set; }
        public string cojNationPlanEndDate { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

    public class cojNationPlanStg
    {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long cojNationPlanId { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

    public class cojNationPlanGoal
    {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long cojNationPlanId { get; set; }
        public long cojNationPlanStgId { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

    // public class cojNationPlanGoalArray
    // {
    //     public cojNationPlanGoal[] cojNationPlanGoal { get; set; }
    // }


    public class cojNationPlanGoalIndicator
    {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long cojNationPlanId { get; set; }
        public long cojNationPlanStgId { get; set; }
        public long cojNationPlanGoalId { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

    public class cojNationPlanGuildline
    {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long cojNationPlanId { get; set; }
        public long cojNationPlanStgId { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

    public class cojNationPlanGuildlineItem
    {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long cojNationPlanId { get; set; }
        public long cojNationPlanStgId { get; set; }
        public long cojNationPlanGuildlineId { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }   
    }

    public class cojNationStg
    {
        public long id { get; set; }
        public long idRef { get; set; }
        public string name { get; set; }
        public string vision { get; set; }
        public string cojNationStgStartDate { get; set; }
        public string cojNationStgEndDate { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

    public class cojNationStgSector
    {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long cojNationStgId { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

    public class cojNationStgIssue
    {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long cojNationStgId { get; set; }
        public long cojNationStgSectorId { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

    public class cojNationStgIndicator
    {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long cojNationStgId { get; set; }
        public long cojNationStgSectorId { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }
}