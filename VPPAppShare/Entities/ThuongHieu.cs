using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VPPAppShare.Entities
{
    [Table("ThuongHieus")]
    public class ThuongHieu
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng không để trống")]
        [MaxLength(100, ErrorMessage = "Nội dung không được vượt quá 100 ký tự")]
        public string TenThuongHieu { get; set; }
        public string Logo { get; set; }
        public string Banner { get; set; }
        public string Website { get; set; }

        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}