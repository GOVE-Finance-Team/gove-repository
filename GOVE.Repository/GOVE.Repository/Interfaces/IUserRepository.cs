using GOVE.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOVE.Repository.Interfaces
{
    public interface IUserRepository
    {
        //Task<bool> ValidateCredentials(string username, string password);
        //Task<Login> FindById(string id);
        Task<Login?> FindByUsername(string username);
        //Task<List<UserMenu>> GetUserMenus(int userId);
    }
}
