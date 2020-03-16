using System.ComponentModel.DataAnnotations;


namespace cojApi.Models
{
    public class spCojFYTransferRequest {
        [Key]
        public long id { get; set; }
        public long idRef { get; set; }
        public long cojAgencyRequest { get; set; }
        public string cojAgencyRequestName { get; set; }
        public int transferFy { get; set; }
        public int transferQuater { get; set; }
        public long transferNO { get; set; }
        public long cojAgencyRequestNO { get; set; }
        public string cojAgencyRequestDate { get; set; }
        public string cojAgencyRequestDocNO { get; set; }
        public string cojAgencyRequestDocDate { get; set; }
        public long cojBGTransferType { get; set; }
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
        public long cojBGTransferRequestId { get; set; }
        public long cojBGTransferId { get; set; }
    }

}