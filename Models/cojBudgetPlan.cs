using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cojApi.Models {

    public class cojBGPlan {
        public long id { get; set; }
        public long idRef { get; set; }
        public string name { get; set; }
        public string cojBGPlanDate { get; set; }
        public string cojBGPlanDocNumber { get; set; }
        public long status { get; set; }
        public long cojPeriod { get; set; }
        public long cojFund { get; set; }
        public string remark { get; set; }
        public double cojBGPlanSumA { get; set; }
        public double cojBGPlanSumB { get; set; }
        public double cojBGPlanSumC { get; set; }
        public double cojBGPlanSumAMT { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string note { get; set; }
    }

    public class cojBGPlanSum {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long cojBGPlanId { get; set; }
        public long cojWorkplanTypeId { get; set; }
        public double cojBGPlanSumA { get; set; }
        public double cojBGPlanSumB { get; set; }
        public double cojBGPlanSumC { get; set; }
        public double cojBGPlanSumAMT { get; set; }
        public string remark { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

    public class cojBGPlanStg {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string nameEN { get; set; }
        public string nameTH { get; set; }
        public long cojBGPlanId { get; set; }
        public long cojStgPlanId { get; set; }
        public long cojStgId { get; set; }
        public double cojBGPlanSumA { get; set; }
        public double cojBGPlanSumB { get; set; }
        public double cojBGPlanSumC { get; set; }
        public double cojBGPlanSumAMT { get; set; }
        public double cojBGPlanSumWork { get; set; }
        public double cojBGPlanSumProject { get; set; }
        public string remark { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

    public class cojBGPlanStgWorkplanType {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long cojBGPlanId { get; set; }
        public long cojStgPlanId { get; set; }
        public long cojStgId { get; set; }
        public long cojWorkplanTypeId { get; set; }
        public double cojBGPlanSumA { get; set; }
        public double cojBGPlanSumB { get; set; }
        public double cojBGPlanSumC { get; set; }
        public double cojBGPlanSumAMT { get; set; }
        public string remark { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

    public class cojBGPlanStgIndicator {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long cojBGPlanId { get; set; }
        public long cojStgPlanId { get; set; }
        public long cojStgId { get; set; }
        public long cojStgIndicatorId { get; set; }
        public string remark { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

    public class cojBGPlanWorkplan {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long cojBGPlanId { get; set; }
        public long cojStgPlanId { get; set; }
        public long cojStgId { get; set; }
        public long cojWorkplanTypeId { get; set; }
        public long cojBGWorkplanId { get; set; }
        public double cojBGPlanSumA { get; set; }
        public double cojBGPlanSumB { get; set; }
        public double cojBGPlanSumC { get; set; }
        public double cojBGPlanSumAMT { get; set; }
        public double cojBGPlanTotalAMT { get; set; }
        public bool cojBGPlanTotalAMTShow { get; set; }
        public string cojAgencys { get; set; }
        public string cojAgencysFulltext { get; set; }
        public string remark { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string procumentAgency { get; set; }
        public string disbursementAgency { get; set; }
        public string responsibilityAgency { get; set; }
    }

    public class cojBGPlanWorkplanActivity {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long cojBGPlanId { get; set; }
        public long cojWorkplanTypeId { get; set; }
        public long cojBGWorkplanId { get; set; }
        public long cojWorkActivityId { get; set; }
        public double cojBGPlanSumA { get; set; }
        public double cojBGPlanSumB { get; set; }
        public double cojBGPlanSumC { get; set; }
        public double cojBGPlanSumAMT { get; set; }
        public double cojBGPlanTotalAMT { get; set; }
        public bool cojBGPlanTotalAMTShow { get; set; }
        public string cojAgencys { get; set; }
        public string cojAgencysFulltext { get; set; }
        public string remark { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }

        public string procumentAgency { get; set; }
        public string disbursementAgency { get; set; }
        public string responsibilityAgency { get; set; }
    }

    public class cojBGPlanWorkplanActivityItem {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long cojBGPlanId { get; set; }
        public long cojWorkplanTypeId { get; set; }
        public long cojBGWorkplanId { get; set; }
        public long cojWorkActivityId { get; set; }
        public long cojWorkActivityItemId { get; set; }
        public string quantityUnit { get; set; }
        public string quantityUnitName { get; set; }
        public string periodStart { get; set; }
        public string periodEnd { get; set; }
        public long budgetTypeId { get; set; }
        public double budgetAmount { get; set; }
        public string cojAgencys { get; set; }
        public bool showInSummary { get; set; }
        public long cojBGWorkplanActivityItemParentId { get; set; }
        public long cojBGWorkplanActivityItemLevel { get; set; }
        public string remark { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string procumentAgency { get; set; }
        public string disbursementAgency { get; set; }
        public string responsibilityAgency { get; set; }
    }

    public class cojBGPlanStgGoals {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long cojBGPlanId { get; set; }
        public long cojStgPlanId { get; set; }
        public long cojStgId { get; set; }
        public long cojBGPlanStgGoal { get; set; }
        public string cojBGPlanStgGoalUnit { get; set; }
        public string remark { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

    public class cojBGPlanWorkplanActivityIndicator {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long cojBGPlanId { get; set; }
        public long cojWorkplanTypeId { get; set; }
        public long cojBGWorkplanId { get; set; }
        public long cojWorkActivityId { get; set; }
        public long cojStgPlanId { get; set; }
        public long cojStgIndicatorId { get; set; }
        public string remark { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

    public class cojBGPlanWorkplanActivityOperation {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long cojBGPlanId { get; set; }
        public long cojWorkplanTypeId { get; set; }
        public long cojBGWorkplanId { get; set; }
        public long cojWorkActivityId { get; set; }
        public long cojStgPlanId { get; set; }
        public long cojStgId { get; set; }
        public long cojStgOperationId { get; set; }
        public string remark { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

    public class cojBGPlanWorkplanActivityObjective {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long cojBGPlanId { get; set; }
        public long cojWorkplanTypeId { get; set; }
        public long cojBGWorkplanId { get; set; }
        public long cojBGWorkplanActivityId { get; set; }
        public string remark { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

    public class cojBGPlanWorkplanActivityObjectiveIndicator {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long cojBGPlanId { get; set; }
        public long cojWorkplanTypeId { get; set; }
        public long cojBGWorkplanId { get; set; }
        public long cojBGWorkplanActivityId { get; set; }
        public long cojBGWorkplanActivityObjectiveId { get; set; }
        public string remark { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

    public class cojBGPlanWorkplanActivityGoal {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long cojBGPlanId { get; set; }
        public long cojWorkplanTypeId { get; set; }
        public long cojBGWorkplanId { get; set; }
        public long cojBGWorkplanActivityId { get; set; }
        public string remark { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

    public class cojBGPlanWorkplanActivityGoalIndicator {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long cojBGPlanId { get; set; }
        public long cojWorkplanTypeId { get; set; }
        public long cojBGWorkplanId { get; set; }
        public long cojBGWorkplanActivityId { get; set; }
        public long cojBGWorkplanActivityGoalId { get; set; }
        public string remark { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

    public class cojBGPlanWorkplanAgency {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long cojBGPlanId { get; set; }
        public long cojBGWorkplanTypeId { get; set; }
        public long cojBGPlanWorkplanId { get; set; }
        public long cojBGPlanWorkplanActivityId { get; set; }
        public long cojAgencyBudgetRoleId { get; set; }
        public long cojAgencyId { get; set; }
        public string remark { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }
    public class cojBGPlanWorkplanActivitySub {
        public long id { get; set; }
        public long idRef { get; set; }
        public long cojBGPlanId { get; set; }
        public long cojBGWorkplanTypeId { get; set; }
        public long cojBGPlanWorkplanId { get; set; }
        public long cojBGWorkplanActivityId { get; set; }
        public string cojBGWorkplanActivitySubCode { get; set; }
        public string cojBGWorkplanActivitySubName { get; set; }
        public string quantityUnit { get; set; }
        public string quantityUnitName { get; set; }
        public string periodStart { get; set; }
        public string periodEnd { get; set; }
        public long budgetTypeId { get; set; }
        public double budgetAmount { get; set; }
        public string remark { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }
    public class cojBGPlanWorkActivityItemSub {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long cojBGPlanId { get; set; }
        public long cojBGWorkplanTypeId { get; set; }
        public long cojBGPlanWorkplanId { get; set; }
        public long cojBGWorkplanActivityId { get; set; }
        public long cojBGWorkplanActivityItemId { get; set; }
        public long cojBGPlanWorkplanActivityItemId { get; set; }
        public string quantityUnit { get; set; }
        public string quantityUnitName { get; set; }
        public string periodStart { get; set; }
        public string periodEnd { get; set; }
        public long budgetTypeId { get; set; }
        public double budgetAmount { get; set; }
        public string remark { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }
    public class cojBGPlanManageRequest {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long userCreate { get; set; }
        public long userUpdate { get; set; }
        public long userAudit { get; set; }
        public string userAuditDate { get; set; }
        public long userApprove { get; set; }
        public string userApproveDate { get; set; }
        public string formData { get; set; }
        public string docData { get; set; }
        public long cojAgencyId { get; set; }
        public long cojPeriod { get; set; }
        public long cojBGPlanManageRequestStatus { get; set; }
        public long cojBGPlanManageType { get; set; }
        public long cojWorkplanTypeId { get; set; }
        public long cojBGWorkplanId { get; set; }
        public string remark { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

    public class fblCojFYWorkplanActivityItem {
        [Key, ColumnAttribute (Order = 0)]
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long cojBGPlanId { get; set; }
        public long cojWorkplanTypeId { get; set; }
        public long cojBGWorkplanId { get; set; }
        public long cojWorkActivityId { get; set; }
        public long cojWorkActivityItemId { get; set; }
        public string quantityUnit { get; set; }
        public string quantityUnitName { get; set; }
        public string periodStart { get; set; }
        public string periodEnd { get; set; }
        public long budgetTypeId { get; set; }
        public double budgetAmount { get; set; }
        public string cojAgencys { get; set; }
        public bool showInSummary { get; set; }
        public long cojBGWorkplanActivityItemParentId { get; set; }
        public long cojBGWorkplanActivityItemLevel { get; set; }
        public string remark { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string procumentAgency { get; set; }
        public string disbursementAgency { get; set; }
        public string responsibilityAgency { get; set; }
        public long cojFund { get; set; }
        public int fy { get; set; }
    }

}