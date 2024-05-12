using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;

namespace ProjectOOP.Pages
{
    public class MH_TongHopModel : PageModel
    {
        [BindProperty]
        public string txtSearch { get; set; } //name phải giống với name của textbox

        private IXuLySanPham _xuLySanPham = new XuLySanPham();

  


        public List<SanPham> DanhSachTongHop;
        public List<SanPham> DanhSachTongHopNew;
        public List<SanPham> dsMua;

        public List<SanPham> dsBan;
        public void OnGet()
        {

            DanhSachTongHop = _xuLySanPham.TongHopSanPham();
            //DanhSachTongHopNew = _xuLySanPham.XuLyTrungLap(DanhSachTongHop);

        }
        public void OnPost()
        {
           
            DanhSachTongHop = _xuLySanPham.TimKiemTongHop(txtSearch);

        }

    }
}
