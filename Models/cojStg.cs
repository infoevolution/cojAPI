namespace cojApi.Models
{

    public class cojStgPlan
    {
        public long id { get; set; }
        public long idRef { get; set; }
        public string name { get; set; }
        public string vision { get; set; }
        public string remark { get; set; }
        public bool active { get; set; }
        public string cojStgPlanStartDate { get; set; }
        public string cojStgPlanEndDate { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

    public class cojStgPlanStg {
        public long id { get; set; }
        public long idRef { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public long cojStgPlanId { get; set; }
        public long cojStgId { get; set; }

    }

    public class cojStg
    {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string nameEN { get; set; }
        public string nameTH { get; set; }
        public string remark { get; set; }
        public string objective { get; set; }
        public long cojStgPlanId { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }

    }

    public class cojStgIndicatorGroup
    {
        public long id { get; set; }
        public long idRef { get; set; }
        public long indicatorGroup { get; set; }
        public long cojStgId { get; set; }
        public long cojStgPlanId { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

    public class cojStgMission
    {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string remark { get; set; }
        public long cojStgPlanId { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

    public class cojStgIndicator
    {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string remark { get; set; }
        public long cojStgIndicatorGroupId { get; set; }
        public long cojStgPlanId { get; set; }
        public long cojStgId { get; set; }
        public long parentId { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }

    }

    public class cojStgOperation
    {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string remark { get; set; }
        public long cojStgIndicatorGroupId { get; set; }
        public long cojStgPlanId { get; set; }
        public long cojStgId { get; set; }
        public long parentId { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }
    public class cojStgPlanStgLink
    {
        public long id { get; set; }
        public long idRef { get; set; }
        public long cojStgPlanId { get; set; }
        public long cojStgId { get; set; }
        public long cojNationStgId { get; set; }
        public long cojNationStgSectorId { get; set; }
        public long cojNationStgIssueId { get; set; }
        public long cojNationPlanId { get; set; }
        public long cojNationPlanStgId { get; set; }
        public long cojNationPlanGuildlineId { get; set; }
        public long cojNationPlanGuildlineItemId { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public long cojPolicyId { get; set; }
        public long cojPolicyLevel1Id { get; set; }
        public long cojPolicyLevel2Id { get; set; }
        public int fy { get; set; }
    
    }
}