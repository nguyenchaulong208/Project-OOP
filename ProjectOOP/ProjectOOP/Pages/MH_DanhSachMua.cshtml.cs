using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repo;
using Services;

namespace ProjectOOP.Pages
{
    public class MH_DanhSachMuaModel : PageModel
    {
        public string Chuoi = string.Empty;

        [BindProperty]
        public string txtSearch { get; set; } //name phải giống với name của textbox

        [BindProperty]
        public DateOnly date { get; set; }

        private IXuLySanPham _xuLySanPham = new XuLySanPham();



        public List<SanPham> DanhSachMua;
        
        public void OnGet()
        {

         _xuLySanPham.loadFile();

           
        if(txtSearch != string.Empty)
            {
                DanhSachMua = _xuLySanPham.DocDanhSachSanPham();
            }
        else
            {
                DanhSachMua = _xuLySanPham.HanSuDung(date);
            }

           

        }
        public void OnPost()
        {
            _xuLySanPham.loadFile();
         
                //DanhSachMua = _xuLySanPham.DocDanhSachSanPham(txtSearch);
           
                DanhSachMua = _xuLySanPham.HanSuDung(date);


           


        }
    }
}
