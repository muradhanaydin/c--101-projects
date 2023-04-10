using api.Application.AuthorOperations.Queries.GetAuthor;
using api.Application.AuthorOperations.Queries.GetAuthorById;
using api.Application.BookOperations.Commands.CreateBook;
using api.Application.BookOperations.Queries.GetBook;
using api.Application.CategoryOperations.Queries;
using api.Application.CategoryOperations.Queries.GetBook;
using api.Entities;
using AutoMapper;

namespace api.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookViewModal , Book>();
            CreateMap<Book , BookViewModel>()
            .ForMember(
                dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name)
            ).ForMember(
                dest => dest.Author , opt => opt.MapFrom(src => $"{src.Author.Name} {src.Author.Surname}")
            ).ForMember(
                dest => dest.PublishedDate , opt => opt.MapFrom(src => src.PublishDate.ToString("dd/MM/yyyy"))
            );
            CreateMap<Book , BookDetailViewModel>()
            .ForMember(
                dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name)
            ).ForMember(
                dest => dest.Author , opt => opt.MapFrom(src => $"{src.Author.Name} {src.Author.Surname}")
            ).ForMember(
                dest => dest.PublishedDate , opt => opt.MapFrom(src => src.PublishDate.ToString("dd/MM/yyyy"))
            ).ForMember(
                dest => dest.CreatedAt , opt => opt.MapFrom(src => src.CreatedAt.ToString("dd/MM/yyyy"))
            );
            CreateMap<Category , CategoryViewModel>();
            CreateMap<Category , CategoryDetailViewModel>();
            CreateMap<Author , AuthorViewModel>();
            CreateMap<Author , AuthorDetailViewModel>();
        }
    }
}