using MyClinicPlusV3.Models;
using MyClinicPlusV3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyClinicPlusV3.Repositories
{
    public interface IUserRepository
    {
        public Task<User> CreateUser(UserRequest userRequest, string roleName);

        public List<User> GetAllUsers();

        public Task<bool> DeleteUser(string email);

        public Task<User> DetailUser(string email);

        public Task<bool> UpdateUser(UserRequest usersViewModel);
    }
}
