using System;
using System.Collections.Generic;

namespace Volunteer.Dto.Models
{
    public class Request : EntityBase
    {

        public string Name { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public DateTime DateOfCreation { get; set; }

        public string PhoneNumber { get; set; }

        public decimal Goal { get; set; }

        public List<Category_Request> Category_Requests { get; set; }

        public Status Status { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
