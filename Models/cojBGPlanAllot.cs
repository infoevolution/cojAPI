using System.ComponentModel.DataAnnotations.Schema;

namespace cojApi.Models {

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

     public class vwCojFYAllotWorkplanActivityBudgetTypeAllot {
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
        public double itemAllotRequestAMT { get; set; }
        public double itemAllotAMT { get; set; }
        public double itemTransferRequestAMT { get; set; }
        public double itemTransferAMT { get; set; }
        public string cojBGWorkplanName { get; set; }
        public string cojWorkActivityName { get; set; }
        public string cojBudgetTypeName { get; set; }
    }

public class vwCojFYAllotWorkplanActivityBudgetType
{
	public long itemNo {get;set;}
	public string key {get;set;}
	public long fy {get;set;}
	public long cojWorkplanTypeId {get;set;}
	public long cojBGWorkplanId {get;set;}
	public long cojWorkActivityId {get;set;}
	public int cojBudgetTypeId {get;set;}
	public double cojBGPlanSumAMT {get;set;}
	public string cojBudgetTypeName {get;set;}
	public double itemAllotRequestAMT {get;set;}
	public double itemAllotAMT {get;set;}
	public double itemTransferRequestAMT {get;set;}
	public double itemTransferAMT {get;set;}
}

public class vwCojFYAllotWorkplanActivity
{
	public long fy {get;set;}
	public long cojWorkplanTypeId {get;set;}
	public long cojBGWorkplanId {get;set;}
	public long cojWorkActivityId {get;set;}
	public string cojWorkActivityName {get;set;}
	public double cojBGPlanSumAMT {get;set;}
	public double itemAllotRequestAMT {get;set;}
	public double itemAllotAMT {get;set;}
	public double itemTransferRequestAMT {get;set;}
	public double itemTransferAMT {get;set;}
}

public class vwCojFYAllotWorkplan
{
	public long fy {get;set;}
	public long cojWorkplanTypeId {get;set;}
	public long cojBGWorkplanId {get;set;}
	public string cojBGWorkplanName {get;set;}
	public double cojBGPlanSumAMT {get;set;}
	public double itemAllotRequestAMT {get;set;}
	public double itemAllotAMT {get;set;}
	public double itemTransferRequestAMT {get;set;}
	public double itemTransferAMT {get;set;}
}

}