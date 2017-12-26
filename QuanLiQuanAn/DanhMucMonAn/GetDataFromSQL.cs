using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DanhMucMonAn
{
    public class GetDataFromSQL
    {
        public static string cnString;
        public static string nameCS = "QLQuanAn";
        public static SqlConnection cn;
        static GetDataFromSQL()
        {
            cnString = ConfigurationManager.ConnectionStrings[nameCS].ConnectionString;
            cn = new SqlConnection(cnString);
        }

        public static SqlCommand CreateCommand()
        {
            if (cn.State == System.Data.ConnectionState.Closed)
            {
                cn.Open();
            }
            var cm = new SqlCommand();
            cm.Connection = cn;
            return cm;
        }
        
        public bool themDanhMuc(DanhMuc danhMuc)
        {
            var cm = CreateCommand();
            cm.CommandText = @"insert into DanhMucMonAn (tenDM,ghiChu) values (@tenDM,@ghiChu)";
            cm.Parameters.Add(new SqlParameter("@tenDM", danhMuc.TenDanhMuc));
            cm.Parameters.Add(new SqlParameter("@ghiChu", danhMuc.GhiChuDanhMuc));
            int rs = cm.ExecuteNonQuery();
            cn.Close();
            return rs > 0;
        }

        public bool capNhatDanhMuc(DanhMuc danhMuc,int maDM)
        {
            var cm = CreateCommand();
            cm.CommandText = @"update DanhMucMonAn set tenDM=@ten, ghiChu=@gc where maDM=@ma";
            cm.Parameters.Add(new SqlParameter("@ten", danhMuc.TenDanhMuc));
            cm.Parameters.Add(new SqlParameter("@gc", danhMuc.GhiChuDanhMuc));
            cm.Parameters.Add(new SqlParameter("@ma", maDM));
            int rs = cm.ExecuteNonQuery();
            cn.Close();
            return rs > 0;
        }
        
        public bool xoaDanhMuc(int maDM)
        {
            var cm = CreateCommand();
            cm.CommandText = @"delete from DanhMucMonAn where maDM=@ma";
            cm.Parameters.Add(new SqlParameter("@ma", maDM));
            int rs = cm.ExecuteNonQuery();
            cn.Close();
            return rs > 0;
        }

        public int timMaDanhMuc(string tenDM)
        {
            var cm = CreateCommand();
            cm.CommandText = @"select maDM from DanhMucMonAn where tenDM=@ten";
            cm.Parameters.Add(new SqlParameter("@ten", tenDM));
            using (var reader = cm.ExecuteReader())
            {

                if (reader.Read())
                {
                    return reader.GetInt32(reader.GetOrdinal("maDM"));
                }
                return 0;
            }
        }

        public SqlDataReader getReader(string chuoisql)
        {
            SqlConnection ketnoi = new SqlConnection(cnString);
            SqlCommand lenh = new SqlCommand(chuoisql, ketnoi);
            ketnoi.Open();
            SqlDataReader docdl1 = lenh.ExecuteReader();
            ketnoi.Close();
            return docdl1;
        }
       
        public DataTable getDataTable(string chuoisql)
        {
            SqlConnection ketnoi = new SqlConnection(cnString);
            SqlCommand lenh = new SqlCommand(chuoisql, ketnoi);
            ketnoi.Open();
            SqlDataAdapter data = new SqlDataAdapter(lenh);
            DataTable bang = new DataTable();
            data.Fill(bang);
            ketnoi.Close();
            return bang;            
        }

        public bool themMonAn(MonAn monAn)
        {
            var cm = CreateCommand();
            cm.CommandText = @"insert into MonAn (tenMA,danhMuc,donGia,donViTinh,ghiChu) values (@a,@b,@c,@d,@e)";
            cm.Parameters.Add(new SqlParameter("@a", monAn.TenMonAn));
            cm.Parameters.Add(new SqlParameter("@b", monAn.DanhMuc));
            cm.Parameters.Add(new SqlParameter("@c", monAn.DonGia));
            cm.Parameters.Add(new SqlParameter("@d", monAn.DonViTinh));
            cm.Parameters.Add(new SqlParameter("@e", monAn.GhiChu));
            int rs = cm.ExecuteNonQuery();
            cn.Close();
            return rs > 0;
        }

        public bool capNhatMonAn(MonAn monAn, int maMA)
        {
            var cm = CreateCommand();
            cm.CommandText = @"update MonAn set tenMA=@a,danhMuc=@b,donGia=@c,donViTinh=@d,ghiChu=@e where maMA=@ma";
            cm.Parameters.Add(new SqlParameter("@a", monAn.TenMonAn));
            cm.Parameters.Add(new SqlParameter("@b", monAn.DanhMuc));
            cm.Parameters.Add(new SqlParameter("@c", monAn.DonGia));
            cm.Parameters.Add(new SqlParameter("@d", monAn.DonViTinh));
            cm.Parameters.Add(new SqlParameter("@e", monAn.GhiChu));
            cm.Parameters.Add(new SqlParameter("@ma", maMA));
            int rs = cm.ExecuteNonQuery();
            cn.Close();
            return rs > 0;
        }

        public bool xoaMonAn(int maMA)
        {
            var cm = CreateCommand();
            cm.CommandText = @"delete from MonAn where maMA=@ma";
            cm.Parameters.Add(new SqlParameter("@ma", maMA));
            int rs = cm.ExecuteNonQuery();
            cn.Close();
            return rs > 0;
        }

        public int timMaMonAn(string tenMA)
        {
            var cm = CreateCommand();
            cm.CommandText = @"select maMA from MonAn where tenMA=@ten";
            cm.Parameters.Add(new SqlParameter("@ten", tenMA));
            using (var reader = cm.ExecuteReader())
            {

                if (reader.Read())
                {
                    return reader.GetInt32(reader.GetOrdinal("maMA"));
                }
                return 0;
            }
        }

        public bool themChiNhanh(ChiNhanh chiNhanh)
        {
            var cm = CreateCommand();
            cm.CommandText = @"insert into ChiNhanh (tenCN,diaChi,dienThoai,tinhThanh) values (@a,@b,@c,@d)";
            cm.Parameters.Add(new SqlParameter("@a", chiNhanh.TenCN));
            cm.Parameters.Add(new SqlParameter("@b", chiNhanh.DiaChi));
            cm.Parameters.Add(new SqlParameter("@c", chiNhanh.DienThoai));
            cm.Parameters.Add(new SqlParameter("@d", chiNhanh.TinhThanh));
            int rs = cm.ExecuteNonQuery();
            cn.Close();
            return rs > 0;
        }

        public int timMaChiNhanh(string tenCN)
        {
            var cm = CreateCommand();
            cm.CommandText = @"select maCN from ChiNhanh where tenCN=@ten";
            cm.Parameters.Add(new SqlParameter("@ten", tenCN));
            using (var reader = cm.ExecuteReader())
            {

                if (reader.Read())
                {
                    return reader.GetInt32(reader.GetOrdinal("maCN"));
                }
                return 0;
            }
        }



        //MENU CHI NHANH
        public bool themMenuChiNhanh(MenuChiNhanh menu)
        {
            var cm = CreateCommand();
            cm.CommandText = @"insert into MenuChiNhanh (maCN,maMA,ghiChu) values (@a,@b,@c)";
            cm.Parameters.Add(new SqlParameter("@a", menu.MaCN));
            cm.Parameters.Add(new SqlParameter("@b", menu.MaMA));
            cm.Parameters.Add(new SqlParameter("@c", menu.GhiChu));
            int rs = cm.ExecuteNonQuery();
            cn.Close();
            return rs > 0;
        }

        public int ExecuteNonQuery(string chuoisql)
        {
            SqlConnection ketnoi = new SqlConnection(cnString);
            SqlCommand lenh = new SqlCommand(chuoisql, ketnoi);
            ketnoi.Open();
            int i = lenh.ExecuteNonQuery();
            ketnoi.Close();
            return i;
        }





    }
}
