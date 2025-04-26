using DevFreela.Application.Models;

namespace DevFreela.Application.Services
{
    public interface IUserService
    {
        ResultViewModel<List<UserViewModel>> GetAll(string search = "", int page = 0, int size = 3);
        ResultViewModel<UserViewModel> GetById(int id);
        ResultViewModel<int> Insert(CreateUserInputModel model);
        ResultViewModel Update(UpdateUserInputModel model);
        ResultViewModel Delete(int id);
        ResultViewModel InsertSkills(int id, UserSkillsInputModel model);
    }
}
