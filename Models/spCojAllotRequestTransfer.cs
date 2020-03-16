using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cojApi.Models {
    public class vwCojAllotRequestTransferFY {
        //[Key]
        public long cojPeriod { get; set; }
        public long fy { get; set; }
        public string name { get; set; }
        public double cojBGPlanSumAMT { get; set; }
        public double itemAllotRequestAMT { get; set; }
        public double itemAllotAMT { get; set; }
        public double itemTransferRequestAMT { get; set; }
        public double itemTransferAMT { get; set; }

    }

    public class vwCojAllotRequestTransferBGPlan {
        //[Key]
        public long cojBGPlanId { get; set; }
        public string cojBGPlanName { get; set; }
        public long cojFund { get; set; }
        public string cojFundName { get; set; }
        public long cojPeriod { get; set; }
        public long fy { get; set; }
        public double cojBGPlanSumAMT { get; set; }
        public double itemAllotRequestAMT { get; set; }
        public double itemAllotAMT { get; set; }
        public double itemTransferRequestAMT { get; set; }
        public double itemTransferAMT { get; set; }
    }

    public class vwCojAllotRequestTransferBGPlanWorkplanType {
        //[Key, ColumnAttribute (Order = 0)]
        public long cojBGPlanId { get; set; }
        //[Key, ColumnAttribute (Order = 1)]
        public long cojWorkplanTypeId { get; set; }
        public string cojWorkplanTypeName { get; set; }
        public double cojBGPlanSumAMT { get; set; }
        public double itemAllotRequestAMT { get; set; }
        public double itemAllotAMT { get; set; }
        public double itemTransferRequestAMT { get; set; }
        public double itemTransferAMT { get; set; }

    }

    public class vwCojAllotRequestTransferBGPlanWorkplan {
        //[Key, ColumnAttribute (Order = 0)]
        public long cojBGPlanId { get; set; }
        //[Key, ColumnAttribute (Order = 1)]
        public long cojWorkplanTypeId { get; set; }
        //[Key, ColumnAttribute (Order = 2)]
        public long cojBGWorkplanId { get; set; }
        public string cojBGWorkplanName { get; set; }
        public double cojBGPlanSumAMT { get; set; }
        public double itemAllotRequestAMT { get; set; }
        public double itemAllotAMT { get; set; }
        public double itemTransferRequestAMT { get; set; }
        public double itemTransferAMT { get; set; }

    }

    public class vwCojAllotRequestTransferBGPlanWorkActivity {
        //[Key, ColumnAttribute (Order = 0)]
        public long cojBGPlanId { get; set; }
        //[Key, ColumnAttribute (Order = 1)]
        public long cojWorkplanTypeId { get; set; }
        //[Key, ColumnAttribute (Order = 2)]
        public long cojBGWorkplanId { get; set; }
        //[Key, ColumnAttribute (Order = 3)]
        public long cojWorkActivityId { get; set; }
        public string cojWorkActivityName { get; set; }
        public double cojBGPlanSumAMT { get; set; }
        public double itemAllotRequestAMT { get; set; }
        public double itemAllotAMT { get; set; }
        public double itemTransferRequestAMT { get; set; }
        public double itemTransferAMT { get; set; }

    }

    public class vwCojAllotRequestTransferBGPlanWorkActivityBudgetType {
        //[Key]
        public long itemNo { get; set; }
        public string key { get; set; }
        public long cojBGPlanId { get; set; }
        public long cojWorkplanTypeId { get; set; }
        public long cojBGWorkplanId { get; set; }
        public long cojWorkActivityId { get; set; }
        public int cojBudgetTypeId { get; set; }
        public double cojBGPlanSumAMT { get; set; }
        public string cojBudgetTypeName { get; set; }
        public double itemAllotRequestAMT { get; set; }
        public double itemAllotAMT { get; set; }
        public double itemTransferRequestAMT { get; set; }
        public double itemTransferAMT { get; set; }
    }

    public class vwCojRequestTransferAllotBGPlanWorkActivityBudgetTypeAllot {
        //[Key]
        public string key { get; set; }
        public long cojBGPlanId { get; set; }
        public long cojWorkplanTypeId { get; set; }
        public long cojBGWorkplanId { get; set; }
        public long cojWorkActivityId { get; set; }
        public long cojFund { get; set; }
        public long cojBudgetType { get; set; }
        public long cojBGPlanAllotId { get; set; }
        public string name {get; set;}
        public long cojBGPlanAllotAgency {get; set;}
        public string cojBGPlanAllotDate {get; set;}
        public long cojBGPlanAllotNO {get; set;}
        public string cojAgencyAllotDocNO {get; set;}
        public string cojAgencyAllotDocDate {get; set;}
        public string operateDate {get; set;}
        public string auditDate {get; set;}
        public string approveDate {get; set;}
        public long operateUser {get; set;}
        public string operateUserName {get; set;}
        public long auditUser {get; set;}
        public string auditUserName {get; set;}
        public long approveUser {get; set;}
        public string approveUserName {get; set;}
        public long cojBGTransferRequestId {get; set;}
        public long cojBGTransferId {get; set;}
        public double itemAllotRequestAMT { get; set; }
        public double itemAllotAMT { get; set; }
        public double itemTransferRequestAMT { get; set; }
        public double itemTransferAMT { get; set; }
    }

}