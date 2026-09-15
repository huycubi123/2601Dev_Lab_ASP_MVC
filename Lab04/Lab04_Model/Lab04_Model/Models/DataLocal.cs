namespace Lab04_Model.Models
{
    public class DataLocal
    {
        public static List<People> _peoples = new List<People>()  // phải là static để có thể truy cập từ bên ngoài và không cần khởi tạo đối tượng
        {
            new People
            {
                Id = 1,
                Name = "Nguyễn Văn Anh",
                Email = "vananh@gmail.com",
                Phone = "0912345671",
                Address = "Hà Nội",
                Avatar = "images/avatars/avt1.jpg",
                Birthday = new DateTime(1998, 5, 15),
                Bio = "Lập trình viên C#",
                Gender = 1 // 1: Nam
            },
            new People
            {
                Id = 2,
                Name = "Trần Thị Bình",
                Email = "thibinh@gmail.com",
                Phone = "0912345672",
                Address = "Đà Nẵng",
                Avatar = "images/avatars/avt2.jpg",
                Birthday = new DateTime(2000, 8, 20),
                Bio = "Thiết kế UI/UX",
                Gender = 0 // 0: Nữ
            },
            new People
            {
                Id = 3,
                Name = "Phạm Gia Cường",
                Email = "giacuong@gmail.com",
                Phone = "0912345673",
                Address = "TP. Hồ Chí Minh",
                Avatar = "images/avatars/avt3.jpg",
                Birthday = new DateTime(1995, 12, 10),
                Bio = "Quản lý dự án",
                Gender = 1
            },
            new People
            {
                Id = 4,
                Name = "Lê Thị Dung",
                Email = "thidung@gmail.com",
                Phone = "0912345674",
                Address = "Hải Phòng",
                Avatar = "images/avatars/avt4.jpg",
                Birthday = new DateTime(2001, 3, 25),
                Bio = "Chuyên viên Marketing",
                Gender = 0
            },
            new People
            {
                Id = 5,
                Name = "Hoàng Văn Em",
                Email = "vanem@gmail.com",
                Phone = "0912345675",
                Address = "Cần Thơ",
                Avatar = "images/avatars/avt5.jpg",
                Birthday = new DateTime(1999, 11, 5),
                Bio = "Kiểm thử phần mềm (Tester)",
                Gender = 1
            }
        };

        // Lấy danh sách dữ liệu 
        public static List<People> GetPeoples()
        {
            return _peoples;
        }

        // Lấy đối tượng theo Id
        public static People GetPeopleById(int id)
        {
            return _peoples.FirstOrDefault(p => p.Id == id);

        }
    }
}
