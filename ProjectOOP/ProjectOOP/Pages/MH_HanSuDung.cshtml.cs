using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;

namespace ProjectOOP.Pages
{
    public class MH_HanSuDungModel : PageModel
    {
        [BindProperty]
   
        public DateOnly date { get; set; }

        private IXuLySanPham _xuLySanPham = new XuLySanPham();



        public List<SanPham> DanhSachHSD;

        public void OnGet()
        {

            _xuLySanPham.loadFile();

                DanhSachHSD = _xuLySanPham.DocDanhSachSanPham();
            

        }
        public void OnPost()
        {
            _xuLySanPham.loadFile();





            DanhSachHSD = _xuLySanPham.HanSuDung(date);

        }
    }
}
