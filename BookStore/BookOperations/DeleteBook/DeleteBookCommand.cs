using BookStore.DBOperations;
using System;
using System.Linq;

namespace BookStore.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        public int BookID { get; set; }
        private readonly BookStoreDbContext _dbcontext;

        public DeleteBookCommand(BookStoreDbContext context)
        {
            _dbcontext = context;
        }

        public void Handle()
        {  
            //Eğer BookID'ye sahip bir kitap veritabanında bulunursa, bu sorgu o kitap nesnesini döndürecektir.
            //Eğer BookID'ye sahip kitap veritabanında bulunmazsa, SingleOrDefault metodu null değeri döndürür.
            var book = _dbcontext.Books.SingleOrDefault(x => x.BookID == BookID);

            if (book is null)
            {
                throw new InvalidOperationException("The book to be deleted could not be found.");
            }

            _dbcontext.Books.Remove(book); //BookID eşitse sil
            _dbcontext.SaveChanges();
        }
    }
}
