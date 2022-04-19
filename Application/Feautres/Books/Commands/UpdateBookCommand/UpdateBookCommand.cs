using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Feautres.Books.Commands.UpdateBookCommand
{
    public class UpdateBookCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Publisher { get; set; }
        public string? Genre { get; set; }
        public double? Price { get; set; }
    }

    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Book> _booksRepository;
        private IMapper _mapper;

        public UpdateBookCommandHandler(IRepositoryAsync<Book> booksRepository, IMapper mapper)
        {
            _booksRepository = booksRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _booksRepository.GetByIdAsync(request.Id);

            if (book == null)
            {
                throw new KeyNotFoundException($"Book con el id {request.Id} no fue encontrado");
            }
            else
            {
                book.Title = request.Title;
                book.Author = request.Author;
                book.Publisher = request.Publisher;
                book.Genre = request.Genre;
                book.Price = request.Price;

                await _booksRepository.UpdateAsync(book);

                return new Response<int>(book.Id);
            }
        }
    }
}
