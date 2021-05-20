using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPPAppShare.Entities
{
    [Table("SanPhams")]
    public class SanPham
    {
         public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng không để trống")]
        [MaxLength(100, ErrorMessage = "Nội dung không được vượt quá 100 ký tự")]
        public string TenSanPham { get; set; }
        public string MoTa { get; set; }
        public string DonViTinh { get; set; }
        public bool TamAn { get; set; }
        public string BarCode { get; set; }
        public int TonKho { get; set; }
        public int DaBan { get; set; }
        public int DanhGia { get; set; }
        
        public int ThuongHieuId { get; set; }
        public virtual ThuongHieu  ThuongHieu { get; set; }
        public int LoaiSPId { get; set; }
        public virtual LoaiSP LoaiSP { get; set; }
        public virtual ICollection<HinhAnh> HinhAnhs { get; set; }
    }
}
