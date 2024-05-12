﻿using Entities;
using Repo;
using System;
using static Services.XuLySanPham;

namespace Services
{
    public class XuLySanPham : IXuLySanPham
    {

        //Dependencies den interface
        private ILuuTruSanPham _luuTruSanPham = new LuuTruSanPham();
        public void loadFile()
        {
            string _file = "../dssp.txt";
            _luuTruSanPham.FilePath(_file);
        }
        public void loadFileOut()
        {
            string _file = "../dsspOut.txt";
            _luuTruSanPham.FilePath(_file);
        }
        public List<SanPham> DocDanhSachSanPham(string tuKhoa = "")
        {

            List<SanPham> kq = new List<SanPham>();
            var dssp = _luuTruSanPham.DocDanhSachSanPham();
            foreach (var sp in dssp)
            {

                if (sp.tenSP.Contains(tuKhoa) || Convert.ToString(sp.maSP).Contains(tuKhoa) || sp.loaiHang.Contains(tuKhoa))
                {
                    kq.Add(sp);
                }


            }
            return kq;
        }
        public void ThemSanPham(SanPham sanPham)
        {


            var dssp = _luuTruSanPham.DocDanhSachSanPham();

            int maxID = 0; //maSP danh so tu dong
            //Kiem tra
            foreach (var sp in dssp)
            { //Lay ma san pham trong danh sach da luu de gan vao maxID
              //=> danh so tu dong cho cac ma san pham tiep theo
                if (sp.maSP > maxID)
                {
                    maxID = sp.maSP;
                }
            }
            //Tao maSP tu dong
            sanPham.maSP = maxID + 1;
            _luuTruSanPham.ThemSanPham(sanPham);
        }
        public void SuaSanPham(SanPham sanPham)
        {
            var ds = _luuTruSanPham.DocDanhSachSanPham();
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].maSP == sanPham.maSP && ds[i].soHoaDon == sanPham.soHoaDon)
                {
                    ds[i] = sanPham;

                }
            }
            _luuTruSanPham.LuuDanhSachSanPham(ds);
        }


        public List<SanPham> DanhSachTongHop()
        {
            
            List<SanPham> LoadDs = _luuTruSanPham.DocDanhSachSanPham();
            List<SanPham> dsSP = new List<SanPham>();
            foreach (var sp in LoadDs)
            {
                bool found = false;
                // Duyệt qua danh sách dsMua để kiểm tra xem sản phẩm đã được thêm vào dschưa
                foreach (var item in dsSP)
                {
                    if (sp.maSP == item.maSP)
                    {
                        // Tăng số lượng sản phẩm nếu đã có trong dsMua
                        item.soLuong += sp.soLuong;
                        found = true; 
                        break;
                        
                    }
                    
                }
                // Nếu sản phẩm chưa có trong dsMua, thêm vào danh sách
                if(!found)
                {
                   
                    dsSP.Add(sp);
                }
             
                
            }
            return dsSP;
        }


        public List<SanPham> TongHopSanPham()
        {
            List<SanPham> TongHop = new List<SanPham>();
            loadFile();
            List<SanPham> dsMua = DanhSachTongHop();
      
            loadFileOut();
            List<SanPham> dsBan = DanhSachTongHop();

            foreach(var item in dsMua)
            {
                bool check = false;
                foreach (var item2 in dsBan)
                {
                    if(item.maSP== item2.maSP)
                    {

                        item2.soLuong += item.soLuong;
                        check = true;
                        break;
                    }

                }
                if (!check)
                {
                    TongHop.Add(item);
                }
            }

            // Thêm danh sách sản phẩm bán vào danh sách tổng hợp
            TongHop.AddRange(dsBan);
        

            return TongHop;
        }

        public List<SanPham> TimKiemTongHop(string tuKhoa = "")
        {

            List<SanPham> kq = new List<SanPham>();
            var dssp = TongHopSanPham();
            foreach (var sp in dssp)
            {

                if (sp.tenSP.Contains(tuKhoa) || Convert.ToString(sp.maSP).Contains(tuKhoa) || sp.loaiHang.Contains(tuKhoa))
                {
                    kq.Add(sp);
                }


            }
            return kq;
        }

        public List<SanPham> HanSuDung(DateOnly date)
        {
            List<SanPham> Hsd = new List<SanPham>();
            var DsSanPham = _luuTruSanPham.DocDanhSachSanPham();
            foreach (var item in DsSanPham)
            {
               
                if (item.hanSuDung < DateOnly.FromDateTime(DateTime.Today))
                {
                    Hsd.Add(item);
                }
            }
            return Hsd;
        }
        //private List<SanPham> DocHanSuDung(List<SanPham> sanPham)
        //{

        //}

    }
    

    
}
