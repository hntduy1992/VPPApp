using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VPPAppShare.Entities
{
    [Table("LoaiSPs")]
    public class LoaiSP
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng không để trống")]
        [MaxLength(100,ErrorMessage = "Nội dung không được vượt quá 100 ký tự")]
        public string TenLoaiSp { get; set; }
        public string MoTa { get; set; }
        public string HinhAnh { get; set; }
        public bool TamAn { get; set; }


        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}