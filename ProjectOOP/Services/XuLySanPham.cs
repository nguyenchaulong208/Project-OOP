using Entities;
using Repo;
using static Services.XuLySanPham;

namespace Services
{
    public class XuLySanPham: IXuLySanPham
    {
        private ILuuTruSanPham _luuTruSanPham = new LuuTruSanPham();
        public List<SanPham> DocDanhSachSanPham()
        {
            List<SanPham> kq;
            kq = _luuTruSanPham.DocDanhSachSanPham();
            return kq;
        }

    }
}
