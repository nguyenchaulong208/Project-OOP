using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjectOOP.Pages
{
    public class MH_SuaSanPhamModel : PageModel
    {
        [BindProperty]
        public string MaSP { get; set; }
        [BindProperty]
        public string TenSP { get; set; }
        [BindProperty]
        public int DGia { get; set; }
        [BindProperty]
        public int SoLuong { get; set; }
        [BindProperty]
        public int ThanhTien { get; set; }
        [BindProperty]
        public string ctySX { get; set; }
        [BindProperty]
        public string nam { get; set; }
        [BindProperty]
        public DateTime hsd { get; set; }
        //Tao thong bao sau khi luu
        public string Chuoi { get; set; } = string.Empty;
        public void OnGet()
        {
            //var showSP = new SanPham(TenSP,DGia, SoLuong,ThanhTien,ctySX,nam,hsd);
        }
    }
}
