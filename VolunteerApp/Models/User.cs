namespace VolunteerApp.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string MidName { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedTime { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedTime { get; set; }


        //Relationships
        public virtual List<Request> Requests { get; set; }

        public Role Role { get; set; }

    }
}
