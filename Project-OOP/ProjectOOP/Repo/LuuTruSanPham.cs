﻿using Entities;

namespace Repo
{
    public class LuuTruSanPham : ILuuTruSanPham
    {
        //Đường dẫn file chứa danh sách sản phẩm từ folder Data
        private string _filePath = "D:\\Github Code\\Project-OOP\\ProjectOOP\\dssp.txt";


        public List<SanPham> DocDanhSachSanPham()
        {
            //Doc danh sach san pham tu file
            StreamReader file = new StreamReader(_filePath);
            int n;
            string s = file.ReadLine();
            n = int.Parse(s);
            List<SanPham> dsSanPham = new List<SanPham>();
            for (int i = 0; i < n; i++)
            {
                s = file.ReadLine();
                dsSanPham.Add(new SanPham(s));
            }

            file.Close();
            return dsSanPham;
        }
        public List<SanPham> LuuDanhSachSanPham(List<SanPham> dsSanPham)
        {
            StreamWriter file = new StreamWriter(_filePath);
            file.WriteLine(dsSanPham.Count);
            foreach(var sp in dsSanPham)
            {
                file.WriteLine($"{sp.maSP},{sp.tenSP},{sp.donGia}");
            }
            file.Close ();
            return dsSanPham;
        }
        public void ThemSanPham(SanPham sanPham)
        {
            //Load danh sach da luu
            var dssp = DocDanhSachSanPham();
            //Them sp va danh sach
            dssp.Add(sanPham);
            LuuDanhSachSanPham(dssp);
        }
    }
}
