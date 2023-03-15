using System.ComponentModel.DataAnnotations;


namespace Volunteer.Dto.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Category_Request> Category_Requests { get; set; }
    }
}
