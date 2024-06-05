using Lab5API.AppDBContext;
using Lab5API.Model;
using Microsoft.EntityFrameworkCore;

namespace Lab5API.IRepository.Repository
{
    public class NhanVienRepository : INhanVienRepository
    {
        private readonly AppDbContext _appDBContext;
        public NhanVienRepository(AppDbContext appDbContext)
        {
            _appDBContext = appDbContext;
        }
        public NhanVien AddNhanVien(NhanVien nhanVien)
        {
            try
            {
                _appDBContext.Add(nhanVien);
                _appDBContext.SaveChanges();
                return nhanVien;

            }catch (Exception ex)
            {
                throw new Exception("Lỗi ");
            }
        }

      

        public void DeleteNhanVien(Guid id)
        {
            var findStudentById = _appDBContext.nhanViens.FirstOrDefault(x => x.id == id);
            try
            {
                _appDBContext.nhanViens.Remove(findStudentById);
                _appDBContext.SaveChanges();


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public IEnumerable<NhanVien> GetAll()
        {
           return _appDBContext.nhanViens.ToList();
        }

       

        public NhanVien UpdateNhanVien(NhanVien nhanVien)
        {
            try
            {
                _appDBContext.Update(nhanVien);
                _appDBContext.SaveChanges();
                return nhanVien;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
