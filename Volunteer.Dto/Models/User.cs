namespace Volunteer.Dto.Models
{
    public class User : EntityBase
    {

        public string Surname { get; set; }

        public string Name { get; set; }

        public string MidName { get; set; }

        public virtual List<Request> Requests { get; set; }

        public Role Role { get; set; }

    }
}
