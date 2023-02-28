using System.ComponentModel.DataAnnotations;


namespace VolunteerApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        //Relationships
        public List<Category_Request> Category_Requests { get; set; }
    }
}
