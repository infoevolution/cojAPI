namespace cojApi.Models
{
    public class cojAgency
    {
        public long id { get; set;}
        public long idRef { get; set; }
        public long itemSort { get; set; }
        public string code { get; set;}
        public string name { get; set;}
        public string address { get; set;}
        public long agencyGroup { get; set;}
        public long agencyType { get; set;}
        public long courtType { get; set;}
        public long agencyHost { get; set; }
        public string remark { get; set; }
        public long acctSort { get; set ;}  //ลำดับที่
        public string fundCenterCode { get; set; } //รหัสศูนย์ต้นทุน
        public string activityCode { get; set; } //รหัสกิจกรรมหลัก
        public string govtAcctCode { get; set; } //รหัสบัญชีเงินฝากคลัง
        public string acctRemark { get; set; }
        public bool isAcctAgency { get; set; }//เป็นหน่วยเบิกจ่าย
        public long acctAgencyType { get; set; } //ประเภทหน่วยเบิกจ่าย
        public string createDate { get; set; }
        public string updateDate { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public long status { get; set; }
        public string dateOpen { get; set; }
        public string dateClose { get; set; }
        public long userCreate { get; set; }
        public long userUpdate { get; set; }
        public long userAudit { get; set; }
        public string userAuditDate { get; set; }
        public long userApprove { get; set; }
        public string userApproveDate { get; set; }
        
        
    }

    public class cojAccountBook
    {
        public long id { get; set; }
        public long idRef { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string remark { get; set; }
        public long cojAgencyId { get; set; }
        public long bank { get; set; }
        public long accountType { get; set; }
        public double fund { get; set; }
        public long status { get; set; }
    }

    public class cojAgencyBuilding
    {
        // public long id { get; set;}
        // public long idRef {get; set; }
        // public long cojAgency {get; set; }
        // public long areaType {get; set; }
        // public long buildingType { get; set; }
        // public long itemSort { get; set; }
        // public string name { get; set;}
        // public string land { get; set;}
        // public double space {get; set; }
        // public long floor { get; set; }
        // public long room { get; set; }
        // public double throne { get; set; }
        // public string remark { get; set; }        
        // public string startDate { get; set; }
        // public string endDate { get; set; }

        public long id { get; set; }
        public long idRef { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string cojLandTypeAdocNo { get; set; }
        public string cojLandTypeBdocNo { get; set; }
        public string cojLandTypeCowner { get; set; }
        public string cojLandTypeCdocNo { get; set; }
        public string cojLandTypeD{  get; set; }
        public double cojLandSize { get; set; }
        public string cojLandAddress { get; set; }
        public string code { get; set; }
        public string remark { get; set; }
        public double cojAreaTotal { get; set; }
        public double cojAreaIndorTotal { get; set; }
        public double cojAreaIndorFloor { get; set; }
        public double cojAreaCourtroom { get; set; }
        public double cojAreaCourtSize { get; set; }
        public double cojAreaWorkroom { get; set; }
        public double cojAreaWorkSize { get; set; }
        public double cojAreaWorkWC { get; set; }
        public double cojAreaServiceWC { get; set; }
        public double cojAreaOutdorTotal { get; set; }
        public double cojAreaOutdorParking { get; set; }
        public double cojAreaOutdorField { get; set; }
        public double cojAreaOutdorWalkway { get; set; }
        public double cojAreaOutdorOther { get; set; }
        public double cojAreaGlass { get; set; }
        public double cojHouseTotal { get; set; }
        public double cojCondoSize { get; set; }
        public double cojCondoUnit { get; set; }
        public string cojHousePosition { get; set; }
        public double cojHousePositionUnit { get; set; }
        public double cojHouseRoom { get; set; }
        public double cojHouseRoomArea { get; set; }
        public double cojHouseFitness { get; set; }
        public double cojHouseFitnessArea { get; set; }
        public double cojHouseCenterWC { get; set; }
        public double cojHouseTank { get; set; }
        public double cojAreaIndorGlass { get; set; }
        public long buildingType { get; set; }
        public long cojAgencyId { get; set; }
    }
    public class cojAgencyBuildingOption
    {
        public long id { get; set;}        
        public long idRef {get; set; }
        public long cojAgencyBuildingId { get; set; }
        public string cojAreaIndorOther { get; set; }
        public long cojAreaIndorOtherRoom { get; set; }
        public double cojAreaIndorOtherSize { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }

    }

    public class cojAgencyBuildingHouse
    {
        public long id { get; set;}        
        public long idRef {get; set; }
        public long cojAgencyBuildingId { get; set; }
        public string cojHousePosition { get; set; }
        public long cojHousePositionUnit { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }

    }

        public class cojAgencyBuildingCondo
    {
        public long id { get; set;}        
        public long idRef {get; set; }
        public long cojAgencyBuildingId { get; set; }
        public long cojCondoUnit { get; set; }
        public long cojCondoBuilding { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }

    }

    public class cojAgencyManpower
    {
        public long id { get; set;}        
        public long idRef {get; set; }
        public long cojAgencyId { get; set; }
        public long cojPosition { get; set; }
        public long cojPositionType { get; set; }
        public long cojPositionCeiling { get; set; }
        public long cojPositionOnhand { get; set; }
        public string remark { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

    public class cojAgencyLogin
    {
        public long id { get; set; }
        public long idRef { get; set; }
        public long itemSort { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string position { get; set; }
        public long cojAgencyId { get; set; }
        public string role { get; set; }
        public long status { get; set; }
        public string remark { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

    public class vwCojAgencyAccountBook {
        public long cojAgencyId { get; set;}
        public long agencyType { get; set;}
        public long agencyGroup { get; set;}
        public long acctSort { get; set;}
        public string cojAgencyAccountName { get; set;}
        public string activityCode { get; set;}
        public string fundCenterCode { get; set;}
        public string cojAgencyAccountA { get; set;}
        public string cojAgencyAccountB { get; set;}
        public string cojAgencyAccountC { get; set;}
    }

}