namespace Entities
{
    public class SanPham
    {
        public int maSP {  get; set; }
        public string tenSP { get; set; }
        public int donGia { get; set; }

        //Constructor
        public SanPham(string TenSP, int DonGia)
        {
            tenSP = TenSP;
            donGia = DonGia;
        }
        public SanPham(string s)
        {
            string[] arr = s.Split(',');
            maSP = int.Parse(arr[0]);
            tenSP = arr[1];
            donGia = int.Parse(arr[2]);
        }

    }
}
