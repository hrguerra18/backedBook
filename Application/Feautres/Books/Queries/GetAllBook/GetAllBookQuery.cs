using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Feautres.Books.Queries.GetAllBook
{
    public class GetAllBookQuery : IRequest<Response<List<BookDto>>>
    {
    }


    public class GetAllBookQueryHandler : IRequestHandler<GetAllBookQuery, Response<List<BookDto>>>
    {
        private readonly IRepositoryAsync<Book> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllBookQueryHandler(IRepositoryAsync<Book> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<List<BookDto>>> Handle(GetAllBookQuery request, CancellationToken cancellationToken)
        {
            var listBook = await _repositoryAsync.ListAsync();
            if (listBook.Count == 0)
            {
                throw new KeyNotFoundException("No se encuentras books registrados");
            }
            else
            {
                var listDto = _mapper.Map<List<BookDto>>(listBook);
                return new Response<List<BookDto>>(listDto);


            }
        }
    }
}
