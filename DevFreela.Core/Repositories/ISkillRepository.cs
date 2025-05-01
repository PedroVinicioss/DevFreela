using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface ISkillRepository
    {
        Task<List<Skill>> GetAll(string search = "", int page = 0, int size = 3);
        Task<int> Add(Skill skill);
    }
}
