using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhMucMonAn
{
    public class DanhMuc
    {
        private string tenDanhMuc = "";
        private string ghiChuDanhMuc = "";
        private int maDanhMuc = 0;

        public string TenDanhMuc { get => tenDanhMuc; set => tenDanhMuc = value; }
        public string GhiChuDanhMuc { get => ghiChuDanhMuc; set => ghiChuDanhMuc = value; }
        public int MaDanhMuc { get => maDanhMuc; set => maDanhMuc = value; }
    }
}
