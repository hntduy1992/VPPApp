using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VPPAppShare.Entities
{
    [Table("HinhAnhs")]
    public class HinhAnh
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Vui lòng không để trống")]
        public string LinkSrc { get; set; }

        public int SanPhamId { get; set; }
        public SanPham SanPham { get; set; }
    }
}