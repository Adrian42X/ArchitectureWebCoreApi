using Core.Repositories;
using ProjectDatabase.Context;
using ProjectDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Users
{
    public class UserRepository : IRepository<User>
    {
        private readonly ProjectContext _projectContext;
        public UserRepository(ProjectContext context)
        {
            _projectContext = context;
        }

        public async Task<User> Add(User entity)
        {
            _projectContext.Users.Add(entity);
            _projectContext.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            var user = _projectContext.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                _projectContext.Remove(user);
                _projectContext.SaveChanges();
            }    
        }

        public async Task<User> FindById(int id)
        {
           return await _projectContext.FindAsync<User>(id);
        }

        public User FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public User Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll(int offset,int limit)
        {
            return _projectContext.Users.Skip(offset).Take(limit);
        }

        public User Update(User userUpdate)
        {
            var userUpdated=_projectContext.Users.FirstOrDefault(x => x.Id == userUpdate.Id);
            userUpdated.FirstName=userUpdate.FirstName;
            userUpdated.LastName=userUpdate.LastName;
            userUpdated.password = userUpdate.password;
            _projectContext.SaveChanges();
            return userUpdate;
        }
       
    }
}
