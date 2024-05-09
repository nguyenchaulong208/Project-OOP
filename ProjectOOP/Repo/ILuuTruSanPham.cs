using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public interface ILuuTruSanPham
    {
        List<SanPham> DocDanhSachSanPham();
        void ThemSanPham(SanPham sanPham);
    }
}
