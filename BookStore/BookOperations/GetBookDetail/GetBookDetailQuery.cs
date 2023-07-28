using AutoMapper;
using BookStore.Common;
using BookStore.DBOperations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BookStore.BookOperations.GetBookDetail
{
    public class GetBookDetailQuery
    {
        public int BookID { get; set; }
        private readonly BookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;

        public GetBookDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _dbcontext = context;
            _mapper = mapper;
        }

        public BookDetailViewModel Handle()
        {
            //BookID ile eşleşen kitabı veritabanında aranır. Eğer böyle bir kitap varsa,
            //book değişkenine atanır; yoksa null olur.
            var book = _dbcontext.Books.Where(book => book.BookID == BookID).FirstOrDefault();
            //Eğer book değişkeni null ise, yani kitap bulunamamışsa, InvalidOperationException hatası fırlatılır ve işlem sonlanır.
            if (book is null)
            {
                throw new InvalidOperationException("The book could not be found.");
            }
            //Kitap bulunursa, BookDetailViewModel örneği oluşturulur ve döndürülür: 
            BookDetailViewModel bookdetailviewModel = _mapper.Map<BookDetailViewModel>(book); 

            return bookdetailviewModel;
        }
    }

    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}
