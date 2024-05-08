namespace Entities
{
    public class SanPham
    {
        public int maSP;
        public string tenSP;
        public double donGia;

        //Constructor
        public SanPham(string s)
        {
            string[] arr = s.Split(',');
            maSP = int.Parse(arr[0]);
            tenSP = arr[1];
            donGia = double.Parse(arr[2]);
        }

    }
}
