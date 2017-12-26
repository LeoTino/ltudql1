using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhMucMonAn
{
    public class ChiNhanh
    {
        private int maCN = 0;
        private string tenCN = "";
        private string diaChi = "";
        private string dienThoai = "";
        private string tinhThanh = "";
        private int soLuongBan = 0;
        private int maChiPhi = 0;

        public int MaCN { get => maCN; set => maCN = value; }
        public string TenCN { get => tenCN; set => tenCN = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string DienThoai { get => dienThoai; set => dienThoai = value; }
        public string TinhThanh { get => tinhThanh; set => tinhThanh = value; }
        public int SoLuongBan { get => soLuongBan; set => soLuongBan = value; }
        public int MaChiPhi { get => maChiPhi; set => maChiPhi = value; }
    }
}
