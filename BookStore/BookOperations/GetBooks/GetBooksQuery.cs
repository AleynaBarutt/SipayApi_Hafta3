using AutoMapper;
using BookStore.BookOperations.GetBookDetail;
using BookStore.Common;
using BookStore.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;

        public GetBooksQuery(BookStoreDbContext context, IMapper mapper)
        {
            _dbcontext = context;
            _mapper = mapper;
        }
        public BooksViewModel Handle()
        {
            //// BookID ile eşleşen kitap veritabanında aranır ve book değişkenine atanır.
            var book = _dbcontext.Books.OrderBy(x => x.BookID).ToList<Book>();
            //Eğer book değişkeni null ise, yani kitap bulunamamışsa, InvalidOperationException hatası fırlatılır ve işlem sonlanır.
            if (book is null)
            {
                throw new InvalidOperationException("The book could not be found.");
            }
            //Kitap bulunursa, BookDetailViewModel örneği oluşturulur ve döndürülür: 
            BooksViewModel booksViewModel = _mapper.Map<BooksViewModel>(book);

            return booksViewModel;
        }
     
    }

    public class BooksViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}
