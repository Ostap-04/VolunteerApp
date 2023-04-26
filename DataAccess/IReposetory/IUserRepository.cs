using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Volunteer.DataAccess.IReposetory
{
    public interface IUserRepository
    {
        Task Authenticate(string username, string password);
    }
}
