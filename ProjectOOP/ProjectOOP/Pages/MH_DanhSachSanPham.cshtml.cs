using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;

namespace ProjectOOP.Pages
{
    public class MH_DanhSachSanPhamModel : PageModel
    {
        public string Chuoi = string.Empty;

        [BindProperty]
        public string Tukhoa { get; set; }
        
        private IXuLySanPham _xuLySanPham = new XuLySanPham();
        public List<SanPham> DanhSachSanPham;
        public void OnGet()
        {
            DanhSachSanPham = _xuLySanPham.DocDanhSachSanPham();
            Chuoi = "On Get";
        }
    }
}
