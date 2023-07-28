using AutoMapper;
using BookStore.DBOperations;
using System;
using System.Linq;

namespace BookStore.BookOperations.GetBooks
{
    public class GetByIdQuery
    {
        public int BookID { get; set; }
        private readonly BookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;

        public GetByIdQuery(BookStoreDbContext context, IMapper mapper)
        {
            _dbcontext = context;
            _mapper = mapper;
        }

        public BookGetByIdViewModel Handle()
        {
            //BookID ile eşleşen kitabı veritabanında aranır. Eğer böyle bir kitap varsa,
            //book değişkenine atanır; yoksa null olur.
            var book = _dbcontext.Books.Where(book => book.BookID == BookID).SingleOrDefault();
            //Eğer book değişkeni null ise, yani kitap bulunamamışsa, InvalidOperationException hatası fırlatılır ve işlem sonlanır.
            if (book is null)
            {
                throw new InvalidOperationException("The book could not be found.");
            }
            //Kitap bulunursa, BookDetailViewModel örneği oluşturulur ve döndürülür: 
            BookGetByIdViewModel viewModel = _mapper.Map<BookGetByIdViewModel>(book);

            return viewModel;
        }
    }

    public class BookGetByIdViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}

