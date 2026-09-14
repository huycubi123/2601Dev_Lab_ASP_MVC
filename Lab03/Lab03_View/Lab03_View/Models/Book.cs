using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab03_View.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public int TotalPage { get; set; }
        public string Sumary { get; set; }

        // danh sách các cuốn sách
        public List<Book> GetBookList()
        {
            List<Book> list = new List<Book>()
            {
                new Book { Id = 1, Title = "Book 1", AuthorId = 1, GemreId = 1, Image = "book1.jpg", Price = 10.99f, TotalPage = 200, Sumary = "Summary of Book 1" },
                new Book { Id = 2, Title = "Book 2", AuthorId = 2, GemreId = 2, Image = "book2.jpg", Price = 12.99f, TotalPage = 250, Sumary = "Summary of Book 2" },
                new Book { Id = 3, Title = "Book 3", AuthorId = 1, GemreId = 1, Image = "book3.jpg", Price = 9.99f, TotalPage = 150, Sumary = "Summary of Book 3" },
                new Book { Id = 4, Title = "Book 4", AuthorId = 3, GemreId = 3, Image = "book4.jpg", Price = 15.99f, TotalPage = 300, Sumary = "Summary of Book 4" },
            };
            return list;
        }

        // lấy danh sách các cuốn sách theo id
        public Book GetBookById(int id)
        {
            Book book = GetBookList().FirstOrDefault(b => b.Id == id);
            return book;
        }

        // Select listItem Authors
        public List<SelectListItem> Authors { get; } = new List<SelectListItem>()
        {
                
            new SelectListItem { Value = "1", Text = "Nam Cao" },
            new SelectListItem { Value = "2", Text = "Nguyen Du" },
            new SelectListItem { Value = "3", Text = "Nguyen Trai" },
            new SelectListItem { Value = "4", Text = "Nguyen Huy Thiep" },
        };

        // SelectListItem Gemres
        public List<SelectListItem> Gemres { get; } = new List<SelectListItem>()
        {
            new SelectListItem { Value = "1", Text = "Trinh tham" },
            new SelectListItem { Value = "2", Text = "Kinh di" },
            new SelectListItem { Value = "3", Text = "Tinh cam" },
            new SelectListItem { Value = "4", Text = "Van hoc" },
        };


    }
}
