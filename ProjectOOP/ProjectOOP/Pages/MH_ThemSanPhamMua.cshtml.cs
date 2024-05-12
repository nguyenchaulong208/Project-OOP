using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;

namespace ProjectOOP.Pages
{
    public class MH_ThemSanPhamMuaModel : PageModel
    {
        [BindProperty]
        public string SoHoaDon { get; set; }
        [BindProperty]
        public int MaSP { get; set; }
        //Bind data to properties
        [BindProperty]
        public string TenSP {  get; set; }
        [BindProperty]
        public int DGia {  get; set; }
        [BindProperty]
        public int SoLuong { get; set; }
        [BindProperty]
        public int ThanhTien { get; set; }
        [BindProperty]
        public string ctySX { get; set; }
        [BindProperty]
        public string nam { get; set; }
        [BindProperty]
        public DateOnly hsd { get; set; }
        [BindProperty]
        public string LoaiHang { get; set; }
        //Tao thong bao sau khi luu
        public string Chuoi {  get; set; } = string.Empty;
        //Dependencies den Interface
        private IXuLySanPham _xuLySanPham = new XuLySanPham();
        public void OnGet()
        {
            _xuLySanPham.loadFile();
        }
        public void OnPost()
        {
            _xuLySanPham.loadFile();
            //Kiem tra du lieu va them
            if (string.IsNullOrEmpty(TenSP) || string.IsNullOrEmpty(SoHoaDon) || string.IsNullOrEmpty(ctySX) || string.IsNullOrEmpty(nam))
            {
                Chuoi = "Dữ liệu không hợp lệ";
            }
            if(DGia <= 0 || SoLuong <= 0 || ThanhTien <= 0)
            {
                Chuoi += "Dữ liệu không hợp lệ"; //Neu dong thoi ca 2 deu empty thi ghep chuoi
            }
            if (Chuoi == string.Empty)
            {
                //Them san pham

                var sp = new SanPham(SoHoaDon,MaSP, TenSP, DGia, SoLuong, ThanhTien, ctySX, nam, LoaiHang, hsd);
                
                    _xuLySanPham.ThemSanPham(sp, MaSP);
                
                
                Response.Redirect("/MH_DanhSachMua");
            }
            

        }
    }
}
