using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DevFreelaDbContext _context;
        public UserRepository(DevFreelaDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }

        public async Task AddUserSkills(List<UserSkill> userSkills)
        {
            await _context.UserSkills.AddRangeAsync(userSkills);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exist(int id)
        {
            return await _context.Users.AnyAsync(u => u.Id == id);
        }

        public async Task<List<User>> GetAll(string search = "", int page = 0, int size = 3)
        {
            return await _context.Users
               .Include(u => u.Skills)
                   .ThenInclude(u => u.Skill)
               .Where(u => u.FullName.Contains(search) || u.Email.Contains(search))
               .Skip(page * size)
               .Take(size)
               .ToListAsync();
        }
        
        public async Task<User?> GetDetailsById(int id)
        {
            return await _context.Users
                .Include(u => u.Skills)
                    .ThenInclude(u => u.Skill)
                .SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User?> GetById(int id)
        {
            return await _context.Users
                .SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
