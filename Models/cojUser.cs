namespace cojApi.Models
{
    public class cojUser
    {
        public long id { get; set;}
        public long idRef { get; set;}
        public string userId { get; set;}
        public string password { get; set;}       
        public string firstName { get; set;}
        public string lastName { get; set;}
        public string position { get; set;}
        public long cojAgencyId { get; set;}
        public string email { get; set;}
        public string phone { get; set;}
        public bool status { get; set;}
        public string securityKey { get; set;}
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

    public class cojGroup
    {
        public long id { get; set; }
        public long idRef { get; set; }
        public string groupId { get; set; }
        public string name { get; set; }
        public string remark { get; set; }
        public bool status { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

    public class cojGroupMember
    {
        public long id { get; set; }
        public long idRef { get; set; }
        public long itemNo { get; set; }
        public long groupId { get; set; }
        public long userId { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }

    }

    public class cojGroupRole
    {
        public long id { get; set; }
        public long idRef { get; set; }
        public long groupId { get; set; }
        public string cmd { get; set; }
        public bool add { get; set; }
        public bool edit { get; set; }
        public bool view { get; set; }
        public bool remove { get; set; }
        public bool fullcontrol { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

    public class cojUserRole
    {
        public long id { get; set; }
        public long idRef { get; set; }
        public long userId { get; set; }
        public string cmd { get; set; }
        public bool add { get; set; }
        public bool edit { get; set; }
        public bool view { get; set; }
        public bool remove { get; set; }
        public bool fullcontrol { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }
}