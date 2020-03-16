namespace cojApi.Models
{

    public class cojFormControl
    {
        public long id { get; set; }
        public string key { get; set; }
        public string label { get; set; }
        public string value { get; set; }
        public string type { get; set; }
        public string controlType { get; set; }
        public long categoryId { get; set; }
        public bool required { get; set; }
        public long order { get; set; }
        public string options { get; set; }
    }

}