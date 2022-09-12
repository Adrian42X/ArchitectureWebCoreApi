using ProjectDatabase.Models;

namespace Core.Repositories
{
    public interface IUserRepository
    {
        ApplicationUser Get();
        Task<ApplicationUser> Add(ApplicationUser entity);
        IEnumerable<ApplicationUser> GetAll(int offset,int limit);
        ApplicationUser FindByName(string name);
        Task<ApplicationUser?> FindById(int id);
        Task<ApplicationUser> Update(ApplicationUser entity);
        Task Delete(int id);
    }
}
