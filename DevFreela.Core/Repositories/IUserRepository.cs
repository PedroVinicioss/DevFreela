using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll(string search = "", int page = 0, int size = 3);
        Task<User?> GetById(int id);
        Task<User?> GetDetailsById(int id);
        Task<int> Add(User user);
        Task AddUserSkills(List<UserSkill> userSkills);
        Task Update(User user);
        Task<bool> Exist(int id);
    }
}
