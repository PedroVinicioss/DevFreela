using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Services
{
    public interface IUserService
    {
        ResultViewModel<List<UserViewModel>> GetAll(string search = "", int page = 0, int size = 3);
        ResultViewModel<UserViewModel> GetById(int id);
        ResultViewModel<int> Insert(CreateUserInputModel model);
        ResultViewModel Update(UpdateUserInputModel model);
        ResultViewModel Delete(int id);
        ResultViewModel PostSkills(int id, UserSkillsInputModel model);
    }

    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _context;
        public UserService(DevFreelaDbContext context)
        {
            _context = context;
        }
        public ResultViewModel Delete(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);
            if (user is null)
                return ResultViewModel.Error("User not found");
            
            user.SetAsDeleted();
            _context.Users.Update(user);
            _context.SaveChanges();
            return ResultViewModel.Success();
        }

        public ResultViewModel<List<UserViewModel>> GetAll(string search = "", int page = 0, int size = 3)
        {
            var users = _context.Users
               .Include(u => u.Skills)
                   .ThenInclude(u => u.Skill)
               .Where(u => u.FullName.Contains(search) || u.Email.Contains(search))
               .Skip(page * size)
               .Take(size)
               .ToList();
            var model = users.Select(UserViewModel.FromEntity).ToList();

            return ResultViewModel<List<UserViewModel>>.Success(model);
        }

        public ResultViewModel<UserViewModel> GetById(int id)
        {
            var user = _context.Users
                .Include(u => u.Skills)
                    .ThenInclude(u => u.Skill)
                .SingleOrDefault(u => u.Id == id);

            if (user is null)
                return ResultViewModel<UserViewModel>.Error("User not found");

            var model = UserViewModel.FromEntity(user);
            return ResultViewModel<UserViewModel>.Success(model);
        }

        public ResultViewModel<int> Insert(CreateUserInputModel model)
        {
            var user = new User(model.FullName, model.Email, model.BirthDate);

            _context.Users.Add(user);
            _context.SaveChanges();

            return ResultViewModel<int>.Success(user.Id);
        }

        public ResultViewModel PostSkills(int id, UserSkillsInputModel model)
        {
            var userSkills = model.SkillIds.Select(s => new UserSkill(id, s)).ToList();

            _context.UserSkills.AddRange(userSkills);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }

        public ResultViewModel Update(UpdateUserInputModel model)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == model.IdUser);
            if (user is null)
                return ResultViewModel.Error("User not found");

            user.Update(model.FullName, model.Email, model.BirthDate);
            _context.Users.Update(user);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }
    }
}
