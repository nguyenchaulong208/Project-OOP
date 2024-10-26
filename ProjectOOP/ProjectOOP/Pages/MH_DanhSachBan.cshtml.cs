using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;

namespace ProjectOOP.Pages
{
    public class MH_DanhSachBanModel : PageModel
    {
        
        public string Chuoi = string.Empty;

        [BindProperty]
        public string txtSearch { get; set; } //name phải giống với name của textbox

        private IXuLySanPham _xuLySanPham = new XuLySanPham();

        private string _filePath = "../dssp.txt";


        public List<SanPham> DanhSachBan;

        public void OnGet()
        {

            _xuLySanPham.loadFileOut();

            DanhSachBan = _xuLySanPham.DocDanhSachSanPham();

        }
        public void OnPost()
        {
            _xuLySanPham.loadFileOut();
            DanhSachBan = _xuLySanPham.DocDanhSachSanPham(txtSearch);
        }
    }
    
}
