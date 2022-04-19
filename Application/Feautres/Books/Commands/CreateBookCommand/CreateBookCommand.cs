using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Feautres.Books.Commands.CreateBookCommand
{
    public class CreateBookCommand  : IRequest<Response<int>>
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Publisher { get; set; }
        public string? Genre { get; set; }
        public double? Price { get; set; }
    }

    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Book> _repositoryAsync;
        private readonly IMapper _mapper;
        public CreateBookCommandHandler(IRepositoryAsync<Book> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }


        public async Task<Response<int>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var newRecord = _mapper.Map<Book>(request);
            var data = await _repositoryAsync.AddAsync(newRecord);

            return new Response<int>(data.Id); 
        }
    }
}
