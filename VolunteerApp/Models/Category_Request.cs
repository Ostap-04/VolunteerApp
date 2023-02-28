namespace VolunteerApp.Models
{
    public class Category_Request
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int RequestId { get; set; }

        public Request Request { get; set; }
    }
}
