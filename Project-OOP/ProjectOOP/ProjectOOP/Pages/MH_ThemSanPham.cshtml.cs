using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;

namespace ProjectOOP.Pages
{
    public class MH_ThemSanPhamModel : PageModel
    {
        //Bind data to properties
        [BindProperty]
        public string TenSP {  get; set; }
        [BindProperty]
        public int DGia {  get; set; }
        //Tao thong bao sau khi luu
        public string Chuoi {  get; set; } = string.Empty;
        //Dependencies den Interface
        private IXuLySanPham _xuLySanPham = new XuLySanPham();
        public void OnGet()
        {

        }
        public void OnPost()
        {
            //Kiem tra du lieu va them
            if (string.IsNullOrEmpty(TenSP))
            {
                Chuoi = "Tên không được để trống!";
            }
            if(DGia < 0)
            {
                Chuoi += "Giá không hợp lệ"; //Neu dong thoi ca 2 deu empty thi ghep chuoi
            }
            if (Chuoi == string.Empty)
            {
                //Them san pham
                var sp = new SanPham(TenSP,DGia);
                _xuLySanPham.ThemSanPham(sp);
                Response.Redirect("/MH_DanhSachSanPham");
            }

        }
    }
}
