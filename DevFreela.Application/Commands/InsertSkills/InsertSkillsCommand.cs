using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.InsertSkills
{
    public class InsertSkillsCommand : IRequest<ResultViewModel<int>>
    {
        public string Description { get; set; }
    }
}
