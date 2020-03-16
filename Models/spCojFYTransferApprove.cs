using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cojApi.Models
{
    public class spCojFYTransferApprove {
        [Key]
        public long id { get; set; }
        public long idRef { get; set; }
        public int bgApproveFy { get; set; }
        public int bgApproveQuater { get; set; }
        public long bgApproveNO { get; set; }
        public string bgApproveProposeDate { get; set; }
        public string bgApproveTransferDate { get; set; }
        public long cojBGTransferType { get; set; }
        public string remark { get; set; }
        public double itemAllotRequestA { get; set; }
        public double itemAllotRequestB { get; set; }
        public double itemAllotRequestC { get; set; }
        public double itemAllotRequestAMT { get; set; }
        public double itemTransferRequestA { get; set; }
        public double itemTransferRequestB { get; set; }
        public double itemTransferRequestC { get; set; }
        public double itemTransferRequestAMT { get; set; }
        public double itemTransferA { get; set; }
        public double itemTransferB { get; set; }
        public double itemTransferC { get; set; }
        public double itemTransferAMT { get; set; }
        public long operateUser { get; set; }
        public string operateUserName { get; set; }
        public string operateDate { get; set; }
        public long auditUser { get; set; }
        public string auditUserName { get; set; }
        public string auditDate { get; set; }
        public long approveUser { get; set; }
        public string approveUserName { get; set; }
        public string approveDate { get; set; }
        public int action { get; set; }
    }

    public class spCojBGTransferApproveGetDocument {
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