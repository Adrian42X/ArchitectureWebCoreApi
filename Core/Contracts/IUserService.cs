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
        List<UserList> GetAll();
        User Add(User newUser);
        public void Delete(int id);
        public User Update(User user);
    }
}
