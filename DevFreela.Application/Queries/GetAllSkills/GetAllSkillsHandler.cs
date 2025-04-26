using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkillsHandler : IRequestHandler<GetAllSkillsQuery, ResultViewModel<List<Skill>>>
    {
        private readonly DevFreelaDbContext _context;
        public GetAllSkillsHandler(DevFreelaDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<List<Skill>>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            var skills = await _context.Skills
                .AsNoTracking()
                .Where(s => s.Description.Contains(request.Search))
                .Skip(request.Page * request.Size)
                .Take(request.Size)
                .ToListAsync();

            return ResultViewModel<List<Skill>>.Success(skills);
        }
    }
}
