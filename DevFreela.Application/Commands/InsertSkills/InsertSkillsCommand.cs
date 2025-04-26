using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.InsertSkills
{
    public class InsertSkillsCommand : IRequest<ResultViewModel>
    {
        public int[] SkillIds { get; set; }
        public int Id { get; set; }
    }
}
