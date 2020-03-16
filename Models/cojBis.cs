namespace cojApi.Models
{
    public class cojPeriod
    {
        public long id { get; set; }
        public long idRef { get; set; }
        public string name { get; set; }
        public string remark { get; set; }
        public long periodType { get; set; }
        public long fy { get; set; }
        public string PeriodStartDate { get; set; }
        public string PeriodEndDate { get; set; }        
        public string startDate { get; set; }
        public string endDate { get; set; }

    }

    public class cojWork 
    {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string startDate { get; set; }
        public string endDate {get; set; }

    }

    public class cojWorkActivity
    {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long perentId { get; set; }
        public long cojWorkId { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }

    }

    public class cojWorkSubActivity
    {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long perentId { get; set; }
        public long cojWorkId { get; set; }
        public long cojWorkActivityId { get; set; }
        public string startDate { get; set; }
        public string endDate {get; set; }
    }

    public class cojWorkBudgetType
    {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long perentId { get; set; }
        public long cojWorkId { get; set; }
        public long cojWorkActivityId { get; set; }
        public long cojWorkSubActivityId { get; set; }
        public long budgetType { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }  
    }

    public class cojWorkBudgetObj
    {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long perentId { get; set; }
        public long cojWorkId { get; set; }
        public long cojWorkActivityId { get; set; }
        public long cojWorkSubActivityId { get; set; }
        public long cojWorkBudgetTypeId { get; set; }
        public long budgetType { get; set; }
        public long budgetObj { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

    public class cojWorkBudgetItem
    {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long perentId { get; set; }
        public long cojWorkId { get; set; }
        public long cojWorkActivityId { get; set; }
        public long cojWorkSubActivityId { get; set; }
        public long cojWorkBudgetTypeId { get; set; }
        public long cojWorkBudgetObjId { get; set; }
        public long budgetType { get; set; }
        public long budgetObj { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

    public class cojProject
    {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string objective { get; set; }
        public string projectDateStart { get; set; }
        public string projectDateFinish { get; set; }
        public string scope { get; set; }
        public string contactPerson { get; set; }
        public string contactPhone { get; set; }
        public long func { get; set; }
        public long status { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }

    }
    public class cojBISLink
    {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long cojStgPlanId { get; set; }
        public string remark { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }

    }
    public class cojBISLinkWork
    {
        public long id { get; set; }
        public long idRef { get; set; }
        public long cojBISLinkId { get; set; }
        public long cojStgId { get; set; }
        public long cojWorkId { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public long fy { get; set; }

    }
    public class cojBISWork {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public long fy { get; set; }
        public string remark { get; set; }

    }

    public class cojBISWorkActivity {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long perentId { get; set; }
        public long cojWorkId { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public long fy { get; set; }
        public string remark { get; set; }

    }

    public class cojBISWorkSubActivity {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long perentId { get; set; }
        public long cojWorkId { get; set; }
        public long cojWorkActivityId { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public long fy { get; set; }
        public string remark { get; set; }
    }

    public class cojBISWorkBudgetType {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long perentId { get; set; }
        public long cojWorkId { get; set; }
        public long cojWorkActivityId { get; set; }
        public long cojWorkSubActivityId { get; set; }
        public long budgetType { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public long fy { get; set; }
        public string remark { get; set; }
    }

    public class cojBISWorkBudgetObj {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long perentId { get; set; }
        public long cojWorkId { get; set; }
        public long cojWorkActivityId { get; set; }
        public long cojWorkSubActivityId { get; set; }
        public long cojWorkBudgetTypeId { get; set; }
        public long budgetType { get; set; }
        public long budgetObj { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public long fy { get; set; }
        public string remark { get; set; }
    }

    public class cojBISWorkBudgetItem {
        public long id { get; set; }
        public long idRef { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public long perentId { get; set; }
        public long cojWorkId { get; set; }
        public long cojWorkActivityId { get; set; }
        public long cojWorkSubActivityId { get; set; }
        public long cojWorkBudgetTypeId { get; set; }
        public long cojWorkBudgetObjId { get; set; }
        public long budgetType { get; set; }
        public long budgetObj { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public long fy { get; set; }
        public string remark { get; set; }
    }

}