using Lab04_Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab04_Model.Controllers
{
    public class PeopleController : Controller
    {
        // Hiển thị danh sách 
        public IActionResult Index()
        {
            var _peoples = Models.DataLocal.GetPeoples();
            return View(_peoples);
        }

        // Hiển thị đối tượng theo id 
        // GET: /People/Details/5
        public IActionResult Details(int id)
        {
            var _people = Models.DataLocal.GetPeopleById(id);
            return View(_people);
        }

        // GET: Phương thức tạo đối tượng mới  
        public IActionResult Create()
        {
            People people = new People();
            return View(people);
        }

        // Phương thức Post: Tạo đối tượng mới
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(People model)
        {
            try
            {
                // 1. Lấy danh sách file được gửi lên từ Form (thông qua enctype="multipart/form-data")
                var files = HttpContext.Request.Form.Files;

                // 2. Kiểm tra xem người dùng có chọn file ảnh hay không
                if (files.Count() > 0 && files[0].Length > 0)
                {
                    var file = files[0];
                    var FileName = file.FileName;

                    // Đường dẫn lưu file vật lý vào thư mục: wwwroot/images/avatar (hoặc avatars)
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\avatars", FileName);

                    // Copy file ảnh vào ổ đĩa trên Server
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    // Gán đường dẫn tương đối của ảnh vào thuộc tính Avatar của Model
                    model.Avatar = "images/avatars/" + FileName;
                }

                // 3. Thêm đối tượng People mới vào danh sách dữ liệu dùng chung DataLocal
                DataLocal._peoples.Add(model);

                // 4. Chuyển hướng về trang danh sách (Index)
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                // Nếu có lỗi thì giữ nguyên dữ liệu đã nhập và trả về lại View Create
                return View(model);
            }
        }

    }
}
