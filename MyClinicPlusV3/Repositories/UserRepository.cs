using Microsoft.AspNetCore.Identity;
using MyClinicPlusV3.Models;
using MyClinicPlusV3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyClinicPlusV3.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SignInManager<User> _signInManager;

        private readonly UserManager<User> _userManager;

        public UserRepository(UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _signInManager = signInManager;

            _userManager = userManager;
        }
        public async Task<User> CreateUser(UserRequest userRequest, string roleName)
        {
            var user = new User
            {
                Nombre = userRequest.Nombre,
                Apellido = userRequest.Apellido,
                Email = userRequest.Email
            };

            var result = await _userManager.CreateAsync(user, userRequest.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, roleName);
                return user;
            }
            return new User { };
        }

        public List<User> GetAllUsers()
        {

            var users = _userManager.Users;
            var usersViewModel = new List<User>();
            return usersViewModel;
        }

        public async Task<bool> DeleteUser(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<User> DetailUser(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {

                return user;
            }
            return new User();
        }

        public async Task<bool> UpdateUser(UserRequest usersViewModel)
        {
            


            var oldUser = await _userManager.FindByEmailAsync(usersViewModel.Email);


            oldUser.Nombre = usersViewModel.Nombre;
            oldUser.Apellido = usersViewModel.Apellido;
            oldUser.Email = usersViewModel.Email;
            
            var result = await _userManager.UpdateAsync(oldUser);

            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
