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

        public User Add(User entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public User Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            return _projectContext.Users;
        }

        public User Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
