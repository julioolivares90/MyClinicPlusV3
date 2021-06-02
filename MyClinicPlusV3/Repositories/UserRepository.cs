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
                Email = userRequest.Email,
                UserName = userRequest.Email    
            };

            var result = await _userManager.CreateAsync(user, userRequest.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, roleName);
                return user;
            }
            return new User { };
        }

        public List<UserViewModel> GetAllUsers()
        {

            var users = _userManager.Users.ToList();

            var usersViewModel = new List<UserViewModel>();

            foreach (var item in users)
            {
                var user = new UserViewModel
                {
                    Nombre = item.Nombre,
                    Apellido = item.Apellido,
                    Email = item.Email,
                    UserName = item.UserName
                };
                usersViewModel.Add(user);
            }
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
            oldUser.UserName = usersViewModel.Email;
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
