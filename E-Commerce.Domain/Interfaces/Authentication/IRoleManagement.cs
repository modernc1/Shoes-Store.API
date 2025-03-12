using E_Commerce.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Interfaces.Authentication
{
    public interface IRoleManagement
    {
        Task<string?> GetUserRoleAsync(string userEmail);
        Task<bool> AddUserToRoleAsync(AppUser user, string roleName);
    }
}
