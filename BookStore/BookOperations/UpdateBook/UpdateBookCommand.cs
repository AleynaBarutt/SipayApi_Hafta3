using BookStore.DBOperations;
using System.Linq;
using System;
using static BookStore.BookOperations.CreateBook.CreateBookCommand;

namespace BookStore.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        public int BookID { get; set; }
        public UpdateBookModel Model { get; set; }
        private readonly BookStoreDbContext _dbcontext;

        public UpdateBookCommand(BookStoreDbContext context)
        {
            _dbcontext = context;
        }

        public void Handle()
        {    
            //BookID ile eşleşen kitabı veritabanında aranır. Eğer böyle bir kitap varsa,
            //book değişkenine atanır; yoksa null olur.
            var book = _dbcontext.Books.SingleOrDefault(x => x.BookID == BookID);

            if (book is null)
            {
                throw new InvalidOperationException("The book to be updated could not be found.");
            }
            // Kitapta  güncellenecek kısımlar eşleştirilir ve son olarak SaveChanges ile veritabanına kaydedilir.
            book.Title = Model.Title != default ? Model.Title : book.Title;
            book.GenreID = Model.GenreID != default ? Model.GenreID : book.GenreID;

            _dbcontext.SaveChanges();
        }

        public class UpdateBookModel
        {
            public string Title { get; set; }
            public int GenreID { get; set; }

        }
    }
}
