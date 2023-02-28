using System.ComponentModel.DataAnnotations;

namespace VolunteerApp.Models
{
    public class Guest
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
