using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<ResultViewModel<List<UserViewModel>>>
    {
        public GetAllUsersQuery(string search, int page, int size)
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
