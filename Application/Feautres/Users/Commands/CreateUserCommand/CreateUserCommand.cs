using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Feautres.Users.Commands.CreateUserCommand
{
    public class CreateUserCommand : IRequest<Response<int>>
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<int>>
    {
        private readonly IRepositoryAsync<User> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IRepositoryAsync<User> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repositoryAsync.ListAsync(new UserSpecification(request.Username!));
            if (user == null)
            {
                throw new KeyNotFoundException($"El usuario {request.Username} no se encuentra registrado");
            }
            var userDto = _mapper.Map<User>(request);
            var data = await _repositoryAsync.AddAsync(userDto);

            return new Response<int>(data.Id);
        }
    }
}
