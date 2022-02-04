using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApplication.Data.Entities;

namespace TodoApplication.Services
{
    public interface IApplicationManager
    {
        Task<ApplicationUser> RegisterUser(ApplicationUser user);
        Task LoginUser(int userId);
    }
}
