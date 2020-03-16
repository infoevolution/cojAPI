using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cojApi.Models {
    public class vwCojBGTransferRequestAgency {
        //[Key]
        public int transferFy { get; set; }
        public long cojAgencyRequest { get; set; }
        public int requestCount { get; set; }
        public double requestAMT { get; set; }
        public string cojAgencyRequestName { get; set; }
        public long agencyType { get; set; }
        public string agencyTypeName { get; set; }
        public long courtType { get; set; }

    }

    public class vwCojBGTransferRequestAgencyItem {
        //[Key]
        public long id { get; set; }
        public long idRef { get; set; }
        public int transferFy { get; set; }
        public int transferQuater { get; set; }
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
        public double transferRequestAMT { get; set; }
        public double transferAMT { get; set; }

    }

    public class spCojBGTransferRequestAgencyPropose {
        [Key, ColumnAttribute (Order = 0)]
        public int allotFy { get; set; }
        public int allotQuater { get; set; }
        public long allotType { get; set; }
        public long cojFund { get; set; }

        [Key, ColumnAttribute (Order = 1)]
        public long cojBGPlanAllotToAgency { get; set; }
        public long cojBGTransferId { get; set; }
        public string cojBGPlanAllotToAgencyName { get; set; }
        public long cojAgencyAccountId { get; set; }
        public string cojAgencyAccountName { get; set; }
        public string activityCode { get; set; }
        public string fundCenterCode { get; set; }
        public string cojAgencyAccountA { get; set; }
        public double sumRequestA { get; set; }
        public string cojAgencyAccountB { get; set; }
        public double sumRequestB { get; set; }
        public string cojAgencyAccountC { get; set; }
        public double sumRequestC { get; set; }
        public double sumRegionReserveA { get; set; }
        public double sumRegionReserveB { get; set; }
        public double sumRegionReserveC { get; set; }
        public double sumIntegrationA { get; set; }
        public double sumIntegrationB { get; set; }
        public double sumIntegrationC { get; set; }
    }
    public class spCojBGTransferRequestAgencyProposeSumCOJ {
        [Key, ColumnAttribute (Order = 0)]
        public int allotFy { get; set; }
        public int allotQuater { get; set; }
        
        [Key, ColumnAttribute (Order = 1)]
        public long cojFund { get; set; }
        public long cojBGTransferId { get; set; }
        public string cojAgencyName { get; set; }
        public string cojAgencyAccountA { get; set; }
        public double sumRequestA { get; set; }
        public string cojAgencyAccountB { get; set; }
        public double sumRequestB { get; set; }
        public string cojAgencyAccountC { get; set; }
        public double sumRequestC { get; set; }
        public double sumRegionReserveA { get; set; }
        public double sumRegionReserveB { get; set; }
        public double sumRegionReserveC { get; set; }
        public double sumIntegrationA { get; set; }
        public double sumIntegrationB { get; set; }
        public double sumIntegrationC { get; set; }
    }
    public class spCojBGTransferRequestAgencyProposeSumAgencyType {
        [Key, ColumnAttribute (Order = 0)]
        public int allotFy { get; set; }
        public int allotQuater { get; set; }
        public long cojFund { get; set; }
        public long cojBGTransferId { get; set; }
        [Key, ColumnAttribute (Order = 1)]
        public long agencyType { get; set; }
        public string agencyTypeName { get; set; }
        public double sumRequestA { get; set; }
        public double sumRequestB { get; set; }
        public double sumRequestC { get; set; }
        public double sumRegionReserveA { get; set; }
        public double sumRegionReserveB { get; set; }
        public double sumRegionReserveC { get; set; }
        public double sumIntegrationA { get; set; }
        public double sumIntegrationB { get; set; }
        public double sumIntegrationC { get; set; }
    }
    public class spCojBGTransferRequestAgencyProposeSumAgencyAccount {
        [Key, ColumnAttribute (Order = 0)]
        public long itemNo { get; set; }
        public int allotFy { get; set; }
        public int allotQuater { get; set; }
        public long cojFund { get; set; }
        public long cojBGTransferId { get; set; }
        public long acctSort { get; set; }
        public long agencyType { get; set; }
         [Key, ColumnAttribute (Order = 1)]
         public long cojAgencyAccountId { get; set; }
        public string cojAgencyAccountName { get; set; }
        public string activityCode { get; set; }
        public string fundCenterCode { get; set; }
        public string cojAgencyAccountA { get; set; }
        public double sumRequestA { get; set; }
        public string cojAgencyAccountB { get; set; }
        public double sumRequestB { get; set; }
        public string cojAgencyAccountC { get; set; }
        public double sumRequestC { get; set; }
        public double sumRegionReserveA { get; set; }
        public double sumRegionReserveB { get; set; }
        public double sumRegionReserveC { get; set; }
        public double sumIntegrationA { get; set; }
        public double sumIntegrationB { get; set; }
        public double sumIntegrationC { get; set; }
    }

}