using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;

namespace Application.Feautres.Books.Commands.DeleteBookCommand
{
    public class DeleteBookCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteBookCommandHanlder : IRequestHandler<DeleteBookCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Book> _repositoryAsync;

        public DeleteBookCommandHanlder(IRepositoryAsync<Book> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _repositoryAsync.GetByIdAsync(request.Id);

            if (book == null)
            {
                throw new KeyNotFoundException($"Book con el id {request.Id} no fue encontrado");
            }
            else
            {
                await _repositoryAsync.DeleteAsync(book);

                return new Response<int>(book.Id);
            }
        }
    }
}
