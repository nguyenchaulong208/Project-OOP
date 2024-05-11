namespace Entities
{
    public class SanPham
    {
        public int maSP {  get; set; }
        public string tenSP { get; set; }
        public int soLuong { get; set; }
        public int donGia { get; set; }
        public int thanhTien { get; set; }
        public DateTime hanSuDung { get; set; }
        public string loaiHang { get; set; }
        public string congTySanXuat {  get; set; }
        public string namSanXuat { get; set; }

        //Constructor
        public SanPham(int MaSP, string TenSP,int DGia, int SoLuong,int ThanhTien,string ctySX, string nam, string LoaiHang,  DateTime HanSuDung)
        {
            maSP = MaSP;
            tenSP = TenSP;
            donGia = DGia;
            soLuong = SoLuong;
            thanhTien = ThanhTien;
            hanSuDung = HanSuDung;
            loaiHang = LoaiHang;
            congTySanXuat = ctySX;
            namSanXuat = nam;
        }
        public SanPham(string s)
        {
            string[] arr = s.Split(',');
            maSP = int.Parse(arr[0]);
            tenSP = arr[1];
            donGia = int.Parse(arr[2]);
            soLuong = int.Parse(arr[3]);
            thanhTien = int.Parse(arr[4]);
            hanSuDung = DateTime.Parse(arr[5]);
            loaiHang = arr[6];
            congTySanXuat = arr[7];
            namSanXuat= arr[8];

        }

    }
}
