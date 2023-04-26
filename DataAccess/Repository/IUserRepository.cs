using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volunteer.DataAccess
{
    public interface IUserRepository
    {
        Task<bool> Authenticate(string email, string password);
        Task<List<string>> GetUsersEmail();
    }
}
