using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.InsertUserSkills
{
    public class InsertUserSkillsHandler : IRequestHandler<InsertUserSkillsCommand, ResultViewModel>
    {
        private readonly IUserRepository _repository;
        public InsertUserSkillsHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(InsertUserSkillsCommand request, CancellationToken cancellationToken)
        {
            var userSkills = request.SkillIds.Select(s => new UserSkill(request.Id, s)).ToList();
            await _repository.AddUserSkills(userSkills);

            return ResultViewModel.Success();
        }
    }
}
