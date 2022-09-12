using Core.Contracts;
using Core.Models;
using Core.Repositories;
using Microsoft.AspNetCore.Identity;
using ProjectDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Users.Services
{
    public class UserService : IUserService
    {
        IRepository<ApplicationUser> _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserService(IRepository<ApplicationUser> userRepository, UserManager<ApplicationUser> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public List<UserList> GetAll(int offset,int limit)
        {
            var DALUserList = _userRepository.GetAll(offset,limit);
            return DALUserList.Select(element => new UserList(element)).ToList();
        }

        public async Task<UserList?> GetById(int id)
        {
            var user = await _userRepository.FindById(id);

            return user == null ? null : new UserList(user);
        }

        public async Task<UserList> AddUser(string firstname, string lastname, string password,string username)
        {
            var user=new ApplicationUser { FirstName=firstname,LastName=lastname,UserName=username};

            var result = await _userManager.CreateAsync(user,password);

            if(!result.Succeeded)
            {
                throw new InvalidOperationException($"User cannot be created because" +
                    $"{result.Errors.First().Description}");
            }
            //var addedUser = await _userRepository.Add(user);
            return new UserList(user);
        }

        public async Task<UserList> UpdateUser(int userId,string firstname, string lastname)
        {
            var user =await _userRepository.FindById(userId);
            if (user == null)
            {
                throw new InvalidOperationException("User was not found !");
            }
            user.FirstName = firstname;
            user.LastName = lastname;
            var updateUser=await _userRepository.Update(user);
            return new UserList(updateUser);
        }

        public async Task DeleteUser(int id)
        {
            await _userRepository.Delete(id);
        }
    }
}
