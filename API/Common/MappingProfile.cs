using api.Modal;
using AutoMapper;

namespace api.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookViewModal , Book>();
            CreateMap<Book , BookViewModel>().ForMember(dest => dest.Category, opt => opt.MapFrom(src => ((CategoryEnum)src.Category).ToString())).ForMember(dest => dest.PublishedDate , opt => opt.MapFrom(src => src.PublishDate.ToString("dd/MM/yyyy")));
        }
    }
}