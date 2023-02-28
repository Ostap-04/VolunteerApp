using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VolunteerApp.Models
{
    public class Request
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public DateTime DateOfCreation { get; set; }

        public string PhoneNumber { get; set; }

        public decimal Goal { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedTime { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedTime { get; set; }


        //Relationships

        public List<Category_Request> Category_Requests { get; set; }

        public Status Status { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
