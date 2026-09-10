using Lab02_Controller.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab02_Controller.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            List<Account> accounts = new List<Account>
    {
        new Account()
        {
            Id = 1,
            Name = "Hoàng Anh",
            Email = "anh@gmail.com",
            Phone = "0986456789",
            Address = "Hà Nội",
            Avatar = "/images/Avatar/01.png", 
            Gender = 1,
            Bio = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Vel, magni?",
            Birthday = new DateTime(1998, 7, 15)
        },
        new Account()
        {
            Id = 2,
            Name = "Trường Giang",
            Email = "giang@gmail.com",
            Phone = "0986456789",
            Address = "Hà Nội",
            Avatar = "/images/Avatar/02.png",
            Gender = 1,
            Bio = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Vel, magni?",
            Birthday = new DateTime(1998, 7, 15)
        },
        new Account()
        {
            Id = 3,
            Name = "Hoàng Thúy",
            Email = "thuy@gmail.com",
            Phone = "0986456789",
            Address = "Hà Nội",
            Avatar = "/images/Avatar/03.jpg",
            Gender = 1,
            Bio = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Vel, magni?",
            Birthday = new DateTime(1998, 7, 15)
        }
    };

            ViewBag.Accounts = accounts;
            return View();
        }
        // Định nghĩa URL và Name cho Action Profile
        [Route("ho-so-cua-toi", Name = "profile")]
        public IActionResult Profile(int id)
        {
            // Danh sách tài khoản giả lập
            List<Account> accounts = new List<Account>
            {
                new Account()
                {
                    Id = 1,
                    Name = "Hoàng Anh",
                    Email = "anh@gmail.com",
                    Phone = "0986456789",
                    Address = "Hà Nội",
                    Avatar = "/images/Avatar/01.png",
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(1998, 7, 15)
                },
                new Account()
                {
                    Id = 2,
                    Name = "Trường Giang",
                    Email = "giang@gmail.com",
                    Phone = "0986456789",
                    Address = "Hà Nội",
                    Avatar = "/images/Avatar/02.png",
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(1998, 7, 15)
                },
                new Account()
                {
                    Id = 3,
                    Name = "Hoàng Thúy",
                    Email = "thuy@gmail.com",
                    Phone = "0986456789",
                    Address = "Hà Nội",
                    Avatar = "/images/Avatar/03.jpg",
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(1998, 7, 15)
                }
            };

            // Truy xuất 1 đối tượng theo id truyền vào
            Account account = accounts.FirstOrDefault(ac => ac.Id == id);

            ViewBag.account = account;
            return View();
        }
    }
    }

