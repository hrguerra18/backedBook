using Application.DTOs;
using Application.Feautres.Books.Commands.CreateBookCommand;
using Application.Feautres.Users.Commands.CreateUserCommand;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {

            #region DTOs
            CreateMap<Book, BookDto>();
            CreateMap<User,UserDto>();
            #endregion
            #region Commands
            CreateMap<CreateBookCommand, Book>();
            CreateMap<CreateUserCommand, User>();
            #endregion
        }
    }
}
