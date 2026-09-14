using Lab03_View.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab03_View.Controllers
{
    public class BookController : Controller
    {
        protected Book book = new Book();
        public IActionResult Index()
        {
            // danh sách genres
            ViewBag.authors = book.Authors;
            ViewBag.genres = book.Gemres;  // truyển dữ liệu select list genres sang view
            var books = book.GetBookList(); // lấy danh sách các cuốn sách
            return View(books);  // truyền danh sách các cuốn sách sang view 
        }

        // Tạo action Create để hiển thị form tạo mới sách
        public IActionResult Create()
        {
            ViewBag.authors = book.Authors;
            ViewBag.genres = book.Gemres;  // truyển dữ liệu select list genres sang view
            Book model = new Book();
            return View(model);
        }

        // Tạo action Edit để hiển thị form chỉnh sửa sách
        public IActionResult Edit(int id)
        {
            ViewBag.authors = book.Authors;
            ViewBag.genres = book.Gemres;  // truyển dữ liệu select list genres sang view
            Book model = book.GetBookById(id); // lấy thông tin sách theo id
            return View(model);
        }

     }
}
