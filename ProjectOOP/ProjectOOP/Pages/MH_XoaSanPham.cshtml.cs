using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;

namespace ProjectOOP.Pages
{
    public class MH_XoaSanPhamModel : PageModel
    {

        [BindProperty]
        public string SoHoaDon { get; set; }
        [BindProperty]
        public int MaSP { get; set; }
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
        public DateOnly hsd { get; set; }
        [BindProperty]
        public string LoaiHang { get; set; }
        //Tao thong bao sau khi luu
        public string Chuoi { get; set; } = string.Empty;
        private IXuLySanPham _xuLySanPham = new XuLySanPham();
        public List<SanPham> ds;
        public bool found = false;

        public void OnGet()
        {
            _xuLySanPham.loadFile();
            // Lấy MaSP từ query string
            MaSP = Convert.ToInt32(Request.Query["MaSP"]);

            // Lấy thông tin sản phẩm từ dịch vụ
            ds = _xuLySanPham.DocDanhSachSanPham(Convert.ToString(MaSP));

            // Gán dữ liệu cho các thuộc tính còn lại từ sản phẩm được lấy về
            foreach (var sp in ds)
            {
                if (MaSP == sp.maSP)
                {
                    SoHoaDon = sp.soHoaDon;
                    MaSP = sp.maSP;
                    TenSP = sp.tenSP;
                    DGia = sp.donGia;
                    SoLuong = sp.soLuong;
                    ThanhTien = sp.thanhTien;
                    ctySX = sp.congTySanXuat;
                    nam = sp.namSanXuat;
                    hsd = sp.hanSuDung;
                    LoaiHang = sp.loaiHang;
                    found = true;
                }
            }


        }
        public void OnPost()
        {
            _xuLySanPham.loadFile();

            //var ds = new SanPham(SoHoaDon, MaSP, TenSP, DGia, SoLuong, ThanhTien, ctySX, nam, LoaiHang, hsd);
            _xuLySanPham.XoaSanPham(MaSP);
            Response.Redirect("/MH_DanhSachMua");



        }
    }

}
