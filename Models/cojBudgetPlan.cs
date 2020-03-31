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

    public class cojBGPlanAllot {
        public long id { get; set; }

        public long idRef { get; set; }
        public long cojBGPlanId { get; set; }
        public long cojWorkplanTypeId { get; set; }
        public long cojBGWorkplanId { get; set; }
        public long cojWorkActivityId { get; set; }
        public long cojFund { get; set; }
        public long cojBudgetType { get; set; }
        public long cojBGPlanAllotAgency { get; set; }
        public long cojBGPlanAllotNO { get; set; }
        public string cojBGPlanAllotDate { get; set; }
        public string cojAgencyAllotDocNO { get; set; }
        public string cojAgencyAllotDocDate { get; set; }
        public bool flagAllotWithTransfer { get; set; }
        public bool flagIntegration { get; set; }
        public bool flagRegionReserve { get; set; }
        public long cojBGTransferType { get; set; }
        public long cojBGTransferRequestId { get; set; }
        public long cojBGTransferId { get; set; }
        public int allotFy { get; set; }
        public int allotQuater { get; set; }
        public long allotType { get; set; }
        public long operateUser { get; set; }
        public string operateUserName { get; set; }
        public string operateDate { get; set; }
        public long auditUser { get; set; }
        public string auditUserName { get; set; }
        public string auditDate { get; set; }
        public long approveUser { get; set; }
        public string approveUserName { get; set; }
        public string approveDate { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public bool flagAgencyReserve { get; set; }
        public int cojFundFY { get; set; }
        public long cojCarryOverItemId { get; set; }
    }

    public class cojBGPlanAllotItem {
        public long id { get; set; }
        public long idRef { get; set; }
        public long cojBGPlanAllotId { get; set; }
        public long cojBGPlanAllotToAgency { get; set; }
        public long itemNO { get; set; }
        public string itemName { get; set; }
        public double itemUnit { get; set; }
        public string itemUnitName { get; set; }
        public double itemUnitPrice { get; set; }
        public long itemParentId { get; set; }
        public long itemLevel { get; set; }
        public double itemAllotRequestAMT { get; set; }
        public double itemAllotAMT { get; set; }
        public double itemTransferRequestAMT { get; set; }
        public long cojBGTransferRequestId { get; set; }
        public double itemTransferAMT { get; set; }
        public long cojBGTransferId { get; set; }
        public long itemTypeId { get; set; }
        public bool flagIntegration { get; set; }
        public bool flagRegionReserve { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string responsibilityAgency { get; set; }
        public string procumentAgency { get; set; }
        public string disbursementAgency { get; set; }
        public bool flagAgencyReserve { get; set; }
        public long cojFund { get; set; }
    }
}