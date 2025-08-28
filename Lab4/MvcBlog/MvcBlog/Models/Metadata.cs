using System.ComponentModel.DataAnnotations;

namespace MvcBlog.Models
{
    public class BlogMetadata
    {
        [Required(ErrorMessage = "Tên blog không được để trống")]
        [StringLength(50)]
        [Display(Name = "Tên")]
        public string Name { get; set; }

        [StringLength(500)]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [StringLength(50)]
        [Display(Name = "Người sở hữu")]
        public string Owner { get; set; }

        [Range(1, 100)]
        [Display(Name = "Xếp hạng")]
        public int Rank { get; set; }
    }

    public class PostMetadata
    {
        [Required]
        [StringLength(50, MinimumLength = 5)]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 10)]
        [Display(Name = "Nội dung")]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Blog ID")]
        public int BlogId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Ngày tạo")]
        public System.DateTime CreatedDate { get; set; }
    }
}
