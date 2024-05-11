using Entities;
using Repo;
using static Services.XuLySanPham;

namespace Services
{
    public class XuLySanPham: IXuLySanPham
    {
        //Dependencies den interface
        private ILuuTruSanPham _luuTruSanPham = new LuuTruSanPham();
        public List<SanPham> DocDanhSachSanPham(string tuKhoa = "")
        {
            List<SanPham> kq = new List<SanPham>();
           var dssp = _luuTruSanPham.DocDanhSachSanPham();
            foreach(var sp in dssp)
            {
                
                if (sp.tenSP.Contains(tuKhoa) || Convert.ToString(sp.maSP).Contains(tuKhoa))
                {
                    kq.Add(sp);
                }


            }
            return kq;
        }
        public void ThemSanPham(SanPham sanPham)
        {
            //Load danh sach SP da luu
            var dssp = _luuTruSanPham.DocDanhSachSanPham();

            int maxID = 0; //maSP danh so tu dong
            //Kiem tra
            foreach(var sp in dssp)
            { //Lay ma san pham trong danh sach da luu de gan vao maxID
              //=> danh so tu dong cho cac ma san pham tiep theo
                if(sp.maSP > maxID)
                {
                    maxID = sp.maSP;
                }
            }
            //Tao maSP tu dong
            sanPham.maSP = maxID + 1;
            _luuTruSanPham.ThemSanPham(sanPham);
        }
        public void SuaSanPham(SanPham sanPham)
        {
            var ds = _luuTruSanPham.DocDanhSachSanPham();
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].maSP == sanPham.maSP && ds[i].soHoaDon == sanPham.soHoaDon)
                {
                    ds[i] = sanPham;

                }
            }
            _luuTruSanPham.LuuDanhSachSanPham(ds);
        }
        
    }
}
