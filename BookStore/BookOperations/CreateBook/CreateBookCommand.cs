using AutoMapper;
using BookStore.DBOperations;
using System;
using System.Linq;

namespace BookStore.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookViewModel Model { get; set; }  //Bu sınıfın üyeleri (Model) kitap oluşturma işlemiyle ilgili
                                                    //verilere erişebilir veya bu verileri güncelleyebilir.
        private readonly BookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;

        public CreateBookCommand(BookStoreDbContext context, IMapper mapper)
        {
            _dbcontext = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var book = _dbcontext.Books.SingleOrDefault(x => x.Title == Model.Title);

            if (book is not null)
            {
                throw new InvalidOperationException("The book is already available.");
            }
            book = _mapper.Map<Book>(Model); //Modelden gelen kitap verilerini maple
            _dbcontext.Books.Add(book); // Kitap listesine ekle
            _dbcontext.SaveChanges();  //Özellikleri kaydet
        }

        public class CreateBookViewModel
        {
            public string Title { get; set; }
            public int GenreID { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
    }
}
