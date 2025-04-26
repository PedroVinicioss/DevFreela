using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.InsertSkills
{
    public class InsertSkillsHandler : IRequestHandler<InsertSkillsCommand, ResultViewModel<int>>
    {
        private readonly DevFreelaDbContext _context;
        public InsertSkillsHandler(DevFreelaDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<int>> Handle(InsertSkillsCommand request, CancellationToken cancellationToken)
        {
            var skill = new Skill(request.Description);

            await _context.Skills.AddAsync(skill);
            await _context.SaveChangesAsync();

            return ResultViewModel<int>.Success(skill.Id);
        }
    }
}
