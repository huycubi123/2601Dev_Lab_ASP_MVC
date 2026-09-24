using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lab05_Validate_Annotation_Guide.Models
{
    public class Account
    {

        [Key]
        public int Id { get; set; }
        // Sử dụng Data Annotations để validate dữ liệu
        [
            Display(Name = "Họ và tên"),
            Required(ErrorMessage = "Họ không được để trống"),
            MinLength(6, ErrorMessage = "Họ tên ít nhất là 6 ký tự"),
            MaxLength(20, ErrorMessage = "Họ tên tối đa 20 ký tự")
        ]
        public string FullName { get; set; }

        // Sử dụng Data Annotations để validate dữ liệu cho email
        //[Display(Name = "Địa chỉ email")]
        //[Required(ErrorMessage = "Địa chỉ email không được để trống")]
        //[EmailAddress(ErrorMessage = "Địa chỉ email không đúng định dạng")]
        //[DataType(DataType.EmailAddress)]
        [Display(Name = "Địa chỉ email")]
        [Required(ErrorMessage = "Địa chỉ email không được để trống")]
        [StringLength(100, ErrorMessage = "Email không được vượt quá 100 ký tự")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không đúng định dạng")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Email không hợp lệ (Ví dụ hợp lệ: example@domain.com)")]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Số điện thoại")]
        [DataType(DataType.PhoneNumber)]
        //        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Số điện thoại không đúng định dạng")]
        [Remote(action: "VerifyPhone",controller: "Account")] 
        // Sử dụng Remote Validation để kiểm tra số điện thoại có đúng định dạng hay không thay vì sử dụng RegularExpression vì RegularExpression sẽ kiểm tra ngay khi người dùng nhập vào,
        // còn Remote Validation sẽ kiểm tra khi người dùng submit form, điều này giúp giảm thiểu việc kiểm tra quá nhiều lần và tăng hiệu suất của ứng dụng
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string Phone { get; set; }

        [Display(Name = "Địa chỉ thường trú")]
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        [StringLength(35, ErrorMessage = "Địa chỉ không vượt quá 35 ký tự")]
        public string Address { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string Avatar { get; set; }

        [Display(Name = "Ngày sinh")]
        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Display(Name = "Giới tính")]
        public string Gender { get; set; }

        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Link Facebook cá nhân")]
        [Required(ErrorMessage = "Link Facebook không được để trống")]
        [Url(ErrorMessage = "Url phải đúng định dạng bao gồm http hoặc https, tên miền VD: https://facebook.com/itvnsoft")]
        public string Facebook { get; set; }

    }
}
