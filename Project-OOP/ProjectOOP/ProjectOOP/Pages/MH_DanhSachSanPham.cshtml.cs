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
        public string txtSearch { get; set; } //name phải giống với name của textbox
        
        private IXuLySanPham _xuLySanPham = new XuLySanPham();
        public List<SanPham> DanhSachSanPham;
        public void OnGet()
        {
            DanhSachSanPham = _xuLySanPham.DocDanhSachSanPham();

        }
        public void OnPost()
        {
            DanhSachSanPham = _xuLySanPham.DocDanhSachSanPham(txtSearch);
        }
    }
}
