using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cojApi.Models {

    public class vwCojBGTransferApprove {
        public long id { get; set; }
        public long idRef { get; set; }
        public int bgApproveFy { get; set; }
        public int bgApproveQuater { get; set; }
        public long bgApproveNO { get; set; }
        public string bgApproveProposeDate { get; set; }
        public string bgApproveTransferDate { get; set; }
        public long cojBGTransferType { get; set; }
        public string remark { get; set; }
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
    }

    public class vwCojBGTransferRequest {
        public long id { get; set; }
        public long idRef { get; set; }
        public int transferFy { get; set; }
        public int transferQuater { get; set; }
        public long transferNO { get; set; }
        public long cojAgencyRequest { get; set; }
        public long cojAgencyRequestNO { get; set; }
        public string cojAgencyRequestDate { get; set; }
        public string cojAgencyRequestDocNO { get; set; }
        public string cojAgencyRequestDocDate { get; set; }
        public long cojBGTransferType { get; set; }
        public string remark { get; set; }
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
        public long transferOperateUser { get; set; }
        public string transferOperateUserName { get; set; }
        public string transferOperateDate { get; set; }
        public long transferAuditUser { get; set; }
        public string transferAuditUserName { get; set; }
        public string transferAuditDate { get; set; }
        public long transferApproveUser { get; set; }
        public string transferApproveUserName { get; set; }
        public string transferApproveDate { get; set; }
        public long cojBGTransferId { get; set; }
    }

    public class spCojBGTransferRequestAgency {
        [Key]
        public long cojBGPlanAllotToAgency { get; set; }
        public long itemNo { get; set; }
        public long agencyType { get; set; }
        public long cojBGTransferRequestId { get; set; }
        public string cojBGPlanAllotToAgencyName { get; set; }
        public long acctSort { get; set; }
        public double allotRequestA { get; set; }
        public double allotRequestB { get; set; }
        public double allotRequestC { get; set; }
        public double allotRequestAMT { get; set; }
        public double transferRequestA { get; set; }
        public double transferRequestB { get; set; }
        public double transferRequestC { get; set; }
        public double transferRequestAMT { get; set; }
        public double transferA { get; set; }
        public double transferB { get; set; }
        public double transferC { get; set; }
        public double transferAMT { get; set; }
    }

    public class spCojBGTransferRequestAgencyType {
        [Key]
        public long itemNo { get; set; }
        public long agencyType { get; set; }
        public long cojBGTransferRequestId { get; set; }
        public string agencyTypeName { get; set; }
        public double allotRequestA { get; set; }
        public double allotRequestB { get; set; }
        public double allotRequestC { get; set; }
        public double allotRequestAMT { get; set; }
        public double transferRequestA { get; set; }
        public double transferRequestB { get; set; }
        public double transferRequestC { get; set; }
        public double transferRequestAMT { get; set; }
        public double transferA { get; set; }
        public double transferB { get; set; }
        public double transferC { get; set; }
        public double transferAMT { get; set; }
    }

    public class spCojBGTransferRequestAgencyDetail {
        [Key, ColumnAttribute (Order = 0)]
        public long itemNo { get; set; }
        public int fy { get; set; }
        public int quater { get; set; }
        [Key, ColumnAttribute (Order = 1)]
        public long cojAgencyId { get; set; }
        //public long cojBGPlanId { get; set; }
        public long cojWorkplanTypeId { get; set; }
        public long cojBGWorkplanId { get; set; }
        //public long cojWorkActivityId { get; set; }
        public string cojBGWorkplanName { get; set; }
        //public string cojBGWorkActivityName { get; set; }
        public double cojBGAllotA { get; set; }
        public double cojBGAllotB { get; set; }
        public double cojBGAllotC { get; set; }
        public double cojBGAllotAMT { get; set; }
        public long allotType { get; set; }
        public double allotRequestA { get; set; }
        public double allotRequestB { get; set; }
        public double allotRequestC { get; set; }
        public double allotRequestAMT { get; set; }
        public double transferRequestA { get; set; }
        public double transferRequestB { get; set; }
        public double transferRequestC { get; set; }
        public double transferRequestAMT { get; set; }
        public double transferA { get; set; }
        public double transferB { get; set; }
        public double transferC { get; set; }
        public double transferAMT { get; set; }
        public long cojBGPlanAllotId { get; set; }
        public long cojBGTransferId { get; set; }

    }

    public class spCojBGTransferRequestAgencyDetailItem {
        [Key]
        public long idRef { get; set; }
        public long itemNo { get; set; }
        public int fy { get; set; }
        public long cojFund { get; set; }
        public int quater { get; set; }
        public long cojAgencyId { get; set; }
        public long cojBGPlanId { get; set; }
        public long cojWorkplanTypeId { get; set; }
        public long cojBGWorkplanId { get; set; }
        public long cojWorkActivityId { get; set; }
        public string cojFundName { get; set; }
        public string cojBGWorkplanName { get; set; }
        public string cojBGWorkActivityName { get; set; }
        public string itemName { get; set; }
        public double itemUnit { get; set; }
        public string itemUnitName { get; set; }
        public double itemUnitPrice { get; set; }
        public long itemTypeId { get; set; }
        public bool flagIntegration { get; set; }
        public bool flagRegionReserve { get; set; }
        public double itemAllotRequestAMT { get; set; }
        public double cojBGAllotA { get; set; }
        public double cojBGAllotB { get; set; }
        public double cojBGAllotC { get; set; }
        public double cojBGAllotAMT { get; set; }
        public long allotType { get; set; }
        public double allotRequestA { get; set; }
        public double allotRequestB { get; set; }
        public double allotRequestC { get; set; }
        public double allotRequestAMT { get; set; }
        public double transferRequestA { get; set; }
        public double transferRequestB { get; set; }
        public double transferRequestC { get; set; }
        public double transferRequestAMT { get; set; }
        public double transferA { get; set; }
        public double transferB { get; set; }
        public double transferC { get; set; }
        public double transferAMT { get; set; }
        public long cojBudgetType { get; set; }
        public string cojBudgetTypeName { get; set; }
        public long cojBGPlanAllotId { get; set; }
        public double itemTransferAMT { get; set; }
        public long agencyType { get; set; }
        public long cojBGTransferId { get; set; }
    }
}