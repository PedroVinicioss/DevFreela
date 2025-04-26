using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using MediatR;

namespace DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQuery : IRequest<ResultViewModel<List<Skill>>>
    {
        public GetAllSkillsQuery(string search, int page, int size)
        {
            Search = search;
            Page = page;
            Size = size;
        }
        public string Search { get; set; } = string.Empty;
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 3;
    }
}
