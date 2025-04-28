using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DevFreelaDbContext _context;
        public ProjectRepository(DevFreelaDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();

            return project.Id;
        }

        public async Task AddComment(ProjectComment comment)
        {
            await _context.ProjectComments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exist(int id)
        {
            var project = await _context.Projects
                .AsNoTracking()
                .AnyAsync(p => p.Id == id);

            return project;
        }

        public Task<List<Project>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Project?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Project?> GetDetailsById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Project project)
        {
            throw new NotImplementedException();
        }
    }
}
