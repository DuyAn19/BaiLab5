using Lab5API.Model;

namespace Lab5API.IRepository
{
    public interface INhanVienRepository
    {
        IEnumerable<NhanVien> GetAll();
        
        NhanVien AddNhanVien(NhanVien nhanVien);
        NhanVien UpdateNhanVien(NhanVien nhanVien);
        void DeleteNhanVien(Guid id) ;
    }
}
