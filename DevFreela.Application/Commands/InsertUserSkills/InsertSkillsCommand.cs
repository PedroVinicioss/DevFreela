using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.InsertUserSkills
{
    public class InsertUserSkillsCommand : IRequest<ResultViewModel>
    {
        public int[] SkillIds { get; set; }
        public int Id { get; set; }
    }
}
