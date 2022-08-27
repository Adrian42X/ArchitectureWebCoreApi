using Core.Repositories;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<UserRepository> _logger;
        public UserRepository(ProjectContext context, ILogger<UserRepository> logger)
        {
            _projectContext = context;
            _logger = logger;
        }

        public async Task<User> Add(User entity)
        {
            _projectContext.Users.Add(entity);
            await _projectContext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var user = await _projectContext.FindAsync<User>(id);
            if (user != null)
            {
                _projectContext.Users.Remove(user);
                await _projectContext.SaveChangesAsync();
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
            _logger.LogInformation("Getting users with offset={offset} and limit={limit}", offset, limit);
            return _projectContext.Users.OrderBy(u=>u.Id).Skip(offset).Take(limit);
        }

        public async Task<User> Update(User entity)
        {
           await _projectContext.SaveChangesAsync();
           return entity;
        }
    }
}
