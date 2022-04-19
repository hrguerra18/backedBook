using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Feautres.Books.Queries.GetBookById
{
    public class GetBookByIdQuery : IRequest<Response<BookDto>>
    {
        public int Id { get; set; }
    }

    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Response<BookDto>>
    {
        private readonly IRepositoryAsync<Book> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetBookByIdQueryHandler(IRepositoryAsync<Book> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<BookDto>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _repositoryAsync.GetByIdAsync(request.Id);
            if (book == null)
            {
                throw new KeyNotFoundException($"Book con el id {request.Id} no fue encontrado");
            }
            else
            {
                var dto = _mapper.Map<BookDto>(book);
                return new Response<BookDto>(dto);
            }
        }
    }
}
