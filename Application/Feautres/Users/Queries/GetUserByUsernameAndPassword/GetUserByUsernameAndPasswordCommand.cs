using Application.DTOs;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Feautres.Users.Queries.GetUserByUsernameAndPassword
{
    public class GetUserByUsernameAndPasswordCommand : IRequest<Response<UserDto>>
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }

    public class GetUserByUsernameAndPasswordCommandHandler : IRequestHandler<GetUserByUsernameAndPasswordCommand, Response<UserDto>>
    {
        private readonly IRepositoryAsync<User> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetUserByUsernameAndPasswordCommandHandler(IRepositoryAsync<User> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<UserDto>> Handle(GetUserByUsernameAndPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _repositoryAsync.ListAsync(new UserSpecification(request.Username!, request.Password!));
            if (user.Count == 0)
            {
                throw new KeyNotFoundException($"Usuario o password incorrecta");
            }
            else
            {
                var userDto = _mapper.Map<List<UserDto>>(user);
                return new Response<UserDto>(userDto[0]);
            }
            
        }
    }
}
