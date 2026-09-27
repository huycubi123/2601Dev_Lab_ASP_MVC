using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab06_EntityFramework_Guide.Models
{
    // Sử dụng kiểu khai báo như quy tắc của SQl    
    [Table("Category")]
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Tên danh mục không được để trống")]
        [StringLength(100, ErrorMessage = "Tên danh mục không được vượt quá 100 ký tự")]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        [Column(TypeName = "tinyint")]
        public byte? Status { get; set; }
        public DateTime CreatedDate { get; set; }
        // danh sách sản phẩm theo danh mục 
        public ICollection<Product> ?Products { get; set; }
    }
}
