using System.ComponentModel.DataAnnotations;

namespace Lab5API.Model
{
    public class NhanVien
    {
        [Key]
        public Guid id {  get; set; }
        public string Ten { get; set; }
        [Range(18, 70, ErrorMessage = "Tuoi must be between 18 and 70.")]
        public int Tuoi { get; set; }
        public DateTime NamLamViec { get; set; }
        public int Role {  get; set; }
        public int Luong { get; set; }

        [EmailAddress(ErrorMessage = "Email must be a valid Gmail address (@gmail.com).")]
        public string Email { get; set; }
        public bool TrangThai { get; set; }
        public string ChucVu { get; set;}
 
    }
}
