using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhMucMonAn
{
    public class MonAn
    {
        private int maMonAn = 0;
        private string tenMonAn = "";
        private int danhMuc = 0;
        private double donGia = 0;
        private string donViTinh = "";
        private string ghiChu = "";

        public int MaMonAn { get => maMonAn; set => maMonAn = value; }
        public string TenMonAn { get => tenMonAn; set => tenMonAn = value; }
        public int DanhMuc { get => danhMuc; set => danhMuc = value; }
        public double DonGia { get => donGia; set => donGia = value; }
        public string DonViTinh { get => donViTinh; set => donViTinh = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
    }
}
