using Core.Models;
using ProjectDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contracts
{
    public interface IUserService
    {
        List<UserList> GetAll(int offset,int limit);
        Task DeleteUser(int id);
        Task<UserList> AddUser(string firstname,string lastname,string password);
        Task<UserList> GetById(int id);
        Task<UserList> UpdateUser(int userId,string firstname, string lastname);


    }
}
