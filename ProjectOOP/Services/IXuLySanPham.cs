using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IXuLySanPham
    {
        //Hàm trả về danh sách sản phẩm
        List<SanPham> DocDanhSachSanPham(string tuKhoa = "");
        
        //Ham them san pham
        void ThemSanPham(SanPham sanPham);
        void SuaSanPham(SanPham SanPham);
        void loadFile();
        void loadFileOut();


    }
    
}
