using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repo;
using Services;

namespace ProjectOOP.Pages
{
    public class MH_DanhSachMuaModel : PageModel
    {


        [BindProperty]
        public string txtSearch { get; set; } //name phải giống với name của textbox


        private IXuLySanPham _xuLySanPham = new XuLySanPham();



        public List<SanPham> DanhSachMua;
        
        public void OnGet()
        {

         _xuLySanPham.loadFile();

                DanhSachMua = _xuLySanPham.DocDanhSachSanPham();
            


        }
        public void OnPost()
        {
            _xuLySanPham.loadFile();


            DanhSachMua = _xuLySanPham.DocDanhSachSanPham(txtSearch);



        }
    }
}
