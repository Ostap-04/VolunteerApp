using DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volunteer.DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly VolunteerContext _context;

        public UserRepository(VolunteerContext context)
        {
            _context = context;
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            if (await Task.FromResult(_context.User.SingleOrDefault(x => x.Email == email && x.Password == password)) != null)
            {
                return true;
            }
            return false;
        }

        public async Task<List<string>> GetUsersEmail()
        {
            List<string> users = new List<string>();
            foreach (var user in _context.User)
            {
                users.Add(user.Email);
            }
            return await Task.FromResult(users);
        }

        
    }
}
