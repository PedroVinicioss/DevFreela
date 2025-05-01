using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.InsertSkills
{
    public class InsertSkillsHandler : IRequestHandler<InsertSkillsCommand, ResultViewModel<int>>
    {
        private readonly ISkillRepository _repository;
        public InsertSkillsHandler(ISkillRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<int>> Handle(InsertSkillsCommand request, CancellationToken cancellationToken)
        {
            var skill = new Skill(request.Description);
            await _repository.Add(skill);

            return ResultViewModel<int>.Success(skill.Id);
        }
    }
}
