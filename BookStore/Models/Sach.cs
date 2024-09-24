using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    [Table("Sach")]
    public class Sach
    {
        [Key]
        public int MaSach {  get; set; }
        [MaxLength(50)]
        public string? TenSach { get; set; }
        public string? TenTacGia { get; set; }
        public string? HinhAnh { get; set; }
        [Required]
        public double Gia {  get; set; }    
        [Required]
        public int MaTheLoai { get; set; }
        public TheLoai TheLoai { get; set; }    
        public List<ChiTietGioHang> ChiTietGioHangs { get; set; }
        public List<ChiTietDonHang> ChiTietDonHangs { get; set; }

        [NotMapped]
        public string TenTheLoai { get; set; }

    }
}
