﻿using Core.Contracts;
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

        public List<UserList> GetAll(int offset,int limit)
        {
            var DALUserList = _userRepository.GetAll(offset,limit);
            return DALUserList.Select(element => new UserList(element)).ToList();
        }

        public void Delete(int userId)
        {
            _userRepository.Delete(userId);
        }

        public async Task<UserList?> GetById(int id)
        {
            var user = await _userRepository.FindById(id);

            return user == null ? null : new UserList(user);
        }

        public async Task<UserList> AddUser(string firstname, string lastname, string password)
        {
            var user=new User { FirstName=firstname,LastName=lastname,password=password};
            var addedUser = await _userRepository.Add(user);
            return new UserList(addedUser);
        }
    }
}
