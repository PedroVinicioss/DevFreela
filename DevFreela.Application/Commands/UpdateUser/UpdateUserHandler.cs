using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, ResultViewModel>
    {
        private readonly IUserRepository _repository;
        public UpdateUserHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetById(request.IdUser);
            if (user is null)
                return ResultViewModel.Error("User not found");

            user.Update(request.FullName, request.Email, request.BirthDate);
            await _repository.Update(user);

            return ResultViewModel.Success();
        }
    }
}