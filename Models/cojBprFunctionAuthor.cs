namespace cojApi.Models
{
    public class cojBprFunctionAuthor
    {
        public long id { get; set;}
        public long idRef { get; set; }
        public long idBprFunction { get; set;}
        public string cojRoles { get; set;}
        public string description { get; set;}
        public bool canAccess { get; set; }
        public bool canCreate { get; set; }
        public bool canRead { get; set; }
        public bool canUpdate { get; set; }
        public bool canDelete { get; set; }
        public bool canGrant { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

    public class cojBprUserAuthor
    {
        public long id { get; set;}
        public long idRef { get; set; }
        public long idBprFunction { get; set;}        
        public long idUser { get; set; }
        public string description { get; set;}
        public bool canAccess { get; set; }
        public bool canCreate { get; set; }
        public bool canRead { get; set; }
        public bool canUpdate { get; set; }
        public bool canDelete { get; set; }
        public bool canGrant { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

    public class cojBprGroupAuthor
    {
        public long id { get; set;}
        public long idRef { get; set; }
        public long idBprFunction { get; set;}        
        public long idUserGroup { get; set; }
        public string description { get; set;}
        public bool canAccess { get; set; }
        public bool canCreate { get; set; }
        public bool canRead { get; set; }
        public bool canUpdate { get; set; }
        public bool canDelete { get; set; }
        public bool canGrant { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

}