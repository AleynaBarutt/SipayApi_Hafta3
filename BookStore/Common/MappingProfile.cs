using AutoMapper;
using BookStore.BookOperations.GetBooks;
using BookStore.BookOperations.GetBookDetail;
using static BookStore.BookOperations.CreateBook.CreateBookCommand;

namespace BookStore.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookViewModel, Book>();  //source-target, createbookmodel objesi book objesine maplenebilsin
            CreateMap<Book, BookGetByIdViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString())); //booksviewmodel içerisindeki genre'yı belirtilen şekilde maplemek için mapfrom ile nereden mapleneceği belirtilir
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book, BookGetByIdViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreID).ToString()));
        }
    }
}
