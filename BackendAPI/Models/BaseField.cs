namespace BackendAPI.Models
{
    public class BaseField
    {
        public String createdBy { get; set; }
        public DateTime createdOn { get; set; }

        public bool isDeleted { get; set; }
    }
}
