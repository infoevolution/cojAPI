using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cojApi.Models
{
    public class spCojFYTransferAllotWork 
    {
        [Key]
        public long itemNo { get; set; }
        public long fy { get; set; }
        public long cojFund { get; set; }
        public long quater { get; set; }
        public double cojBGAllotA { get; set; }
        public double cojBGAllotB { get; set; }
        public double cojBGAllotC { get; set; }
        public double cojBGAllotAMT { get; set; }
        public long transferType { get; set; }
        public long allotType { get; set; }
        public string cojFundName { get; set; }
        public string allotTypeName { get; set; }
        public int flagAllot {get; set;}
    }

public class spCojFYTransferAllotWorkAgencyType 
    {
        [Key]
        public long itemNo { get; set; }
        public long fy { get; set; }
        public long cojFund { get; set; }
        public int quater { get; set; }
        public string cojAgencyTypeName {get; set;}
        public long cojAgencyType { get; set; }
        public double cojBGAllotA { get; set; }
        public double cojBGAllotB { get; set; }
        public double cojBGAllotC { get; set; }
        public double cojBGAllotAMT { get; set; }
        public long allotType { get; set; }
        
    }
    public class spCojFYTransferAllotWorkAgency 
    {
        [Key]
        public long cojAgencyId {get; set;}
        public long itemNo { get; set; }
        public long fy { get; set; }
        public long cojFund { get; set; }
        public int quater { get; set; }
        public string cojAgencyName {get; set;}
        public long cojAgencyType { get; set; }
        public double cojBGAllotA { get; set; }
        public double cojBGAllotB { get; set; }
        public double cojBGAllotC { get; set; }
        public double cojBGAllotAMT { get; set; }
        public long allotType { get; set; }
        
    }

    public class spCojFYTransferAllotWorkAgencyDetail 
    {
        [Key]
        public long itemNo { get; set; }
        public long fy { get; set; }
        public long cojFund { get; set; }
        public int quater { get; set; }
        public long cojAgencyId {get; set;}
        public long cojBGPlanId {get; set;}
        public long cojWorkplanTypeId {get; set;}
        public long cojWorkActivityId {get; set;}
        public string cojFundName {get; set;}
        public string cojBGWorkplanName {get; set;}
        public string cojBGWorkActivityName {get; set;}
        public double cojBGAllotA { get; set; }
        public double cojBGAllotB { get; set; }
        public double cojBGAllotC { get; set; }
        public double cojBGAllotAMT { get; set; }
        public long allotType { get; set; }
        
    }

}