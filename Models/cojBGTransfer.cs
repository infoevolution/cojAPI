using System;
namespace cojApi.Models
{ 
    public class cojBGTransfer {
        public long id { get; set; }
        public long idRef { get; set; }
        public long cojBGTransferFY { get; set; }
        public long cojBGTransferNO { get; set; }
        public string cojBGTransferDataDate { get; set; }
        public string cojBGTransferPostDate { get; set; } 
        public long cojBGTransferPeriod { get; set; }
        public double cojBGTransferA { get; set; }
        public double cojBGTransferB { get; set; }
        public double cojBGTransferC { get; set; }
        public double cojBGTransferAMT { get; set; }
        public long cojBGTransferType { get; set; }  
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

    public class cojBGTransferDoc {
        public long id { get; set; }
        public long idRef { get; set; }
        public long cojBGTransferId { get; set; }
        public string cojBGTransferDocDate { get; set; }
        public long cojBGTransferDocNO { get; set; }
        public long cojBGTransferAgencyId { get; set; }
        public long cojBGReceiveAgencyId { get; set; }
        public double cojBGTransferA { get; set; }
        public double cojBGTransferB { get; set; }
        public double cojBGTransferC { get; set; }
        public double cojBGTransferAMT { get; set; }
        public long cojBGTransferType { get; set; }  
        public long cojBGTransferFY { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

   public class cojBGTransferDocItem {
        public long id { get; set; }
        public long idRef { get; set; }
        public long cojBGTransferId { get; set; }
        public long cojBGTransferDocId { get; set; }
        public long cojBGPlanId { get; set; }
        public long cojWorkplanType { get; set; }
        public long cojBGWorkplanId { get; set; }
        public long cojWorkActivityId { get; set; }
        public double cojBGTransferA { get; set; }
        public double cojBGTransferB { get; set; }
        public double cojBGTransferC { get; set; }
        public string name {get; set;}
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

}
    