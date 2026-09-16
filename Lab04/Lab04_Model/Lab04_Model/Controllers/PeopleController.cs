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

        // GET: Phương thức tạo đối tượng mới  : Hiển thị form tạo mới
        public IActionResult Create()
        {
            People people = new People();
            return View(people);
        }

        // Phương thức Post: Tạo đối tượng mới
        [HttpPost]
        [ValidateAntiForgeryToken]  // Bảo vệ chống tấn công CSRF
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

        // Phương thức Update: Cập nhật đối tượng theo id

        // GET: /People/Edit/5 tác dung hiển thị form edit
        public IActionResult Edit(int id)
        {
            var _people = Models.DataLocal.GetPeopleById(id);
            return View(_people);
        }

        // POST: Peoples/Edit/5 : Phương thức xử lý cập nhật đối tượng theo id, gửi lên từ form edit sau khi người dùng nhấn nút submit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, People model)
        {
            try
            {
                // 1. Tìm đối tượng cần chỉnh sửa trong danh sách DataLocal
                var item = DataLocal._peoples.FirstOrDefault(x => x.Id == id);
                if (item == null)
                {
                    return NotFound();
                }

                // 2. Kiểm tra xem người dùng có tải lên file ảnh mới hay không
                var files = HttpContext.Request.Form.Files;
                if (files.Count() > 0 && files[0].Length > 0)
                {
                    var file = files[0];
                    var FileName = file.FileName;

                    // Đường dẫn lưu file vào thư mục wwwroot/images/avatar
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\avatar", FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    // Cập nhật đường dẫn ảnh mới
                    item.Avatar = "images/avatar/" + FileName;
                }
                // Lưu ý: Nếu người dùng KHÔNG chọn ảnh mới, item.Avatar vẫn giữ nguyên đường dẫn cũ

                // 3. Cập nhật các thông tin còn lại từ model vào item trong DataLocal
                item.Name = model.Name;
                item.Email = model.Email;
                item.Phone = model.Phone;
                item.Address = model.Address;
                item.Birthday = model.Birthday;
                item.Bio = model.Bio;
                item.Gender = model.Gender;

                // 4. Chuyển hướng về trang danh sách (Index) sau khi cập nhật thành công
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                // Nếu có lỗi, giữ lại thông tin đã nhập và hiển thị lại View Edit
                return View(model);
            }
        }

        // GET: /People/Delete/5 : Hiển thị form xác nhận xóa
        public IActionResult Delete(int id)
        {
            var _people = Models.DataLocal.GetPeopleById(id);
            return View(_people);
        }

        // POST: /People/Delete/5 : Xử lý xóa đối tượng theo id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, People model)
        {
            try
            {
                // 1. Tìm đối tượng cần xóa trong danh sách DataLocal
                var item = DataLocal._peoples.FirstOrDefault(x => x.Id == id);
                if (item == null)
                {
                    return NotFound();
                }

                // 2. Xóa đối tượng khỏi danh sách
                DataLocal._peoples.Remove(item);

                // 3. Chuyển hướng về trang danh sách (Index) sau khi xóa thành công
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                // Nếu có lỗi, giữ lại thông tin và hiển thị lại View Delete
                return View(model);
            }
        }

    }
}
