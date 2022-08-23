using Core.Contracts;
using Core.Models;
using Core.Repositories;
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
        IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public List<UserList> GetAll()
        {
            var DALUserList = _userRepository.GetAll();
            return DALUserList.Select(entity => new UserList
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                
            }).ToList();
        }

        User IUserService.Add(User newUser)
        {
            _userRepository.Add(newUser);
            return newUser;
        }

        public void Delete(int userId)
        {
            _userRepository.Delete(userId);
        }

        public User Update(User user)
        {
            var existingUser = _userRepository.FindById(user.Id);
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.password = user.password;
            _userRepository.Update(existingUser);
            return user;
        }

    }
}
